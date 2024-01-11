using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using RabbitMQ.Client.Events;
using Tesseract;
using System.Drawing;
using System.Diagnostics;
using System.Web;
using System.Runtime.InteropServices;
using System.Reflection;
using Minio;
using Minio.DataModel.Args;
using System.Security.AccessControl;
using Npgsql;
using System.Security.Cryptography;
using System.Reflection.Metadata;
using Newtonsoft.Json;
using System.Net;



var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "guest",
    Password = "guest",
    VirtualHost = "/"
};

var connection = factory.CreateConnection();

using var channel = connection.CreateModel();

channel.QueueDeclare("uploadDocument", durable: true, exclusive: false);

Console.WriteLine(" [*] Waiting for messages.");

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = JsonConvert.DeserializeObject<Document>(Encoding.UTF8.GetString(body));

    Console.WriteLine("new Message:");
    //var file = GetFileFromMinio(message.Title + message.DocumentType);
    GetFileFromMinio(message.Title + ".pdf").Wait();

    ProcessImage(message.Title + ".pdf"); 
    var result = handleMessage(message.Title);

    UpdateDatabaseAsync(result, message.Id );
};

channel.BasicConsume("uploadDocument", true, consumer);

Console.ReadLine();

string handleMessage(string title)
{
    TesseractEngine engine = new TesseractEngine("./tessdata", "eng", EngineMode.Default);
    Page page = engine.Process(Pix.LoadFromMemory(File.ReadAllBytes(title.Replace("\"", "") + ".jpg")), PageSegMode.Auto);
    //Page page = engine.Process(Pix.LoadFromMemory(file), PageSegMode.Auto);
    string result = page.GetText();
    Console.WriteLine(page.GetText());
    return result;
}

void ProcessImage(string inputPDFFile)
{
    var filename = Path.GetFileNameWithoutExtension(inputPDFFile);
    string ghostScriptPath = @"C:\Program Files\gs\gs10.02.1\bin\gswin64.exe";
    String ars = "-dNOPAUSE -sDEVICE=jpeg -r102.4 -o" + Environment.CurrentDirectory + "\\" + filename + ".jpg -sPAPERSIZE=a4 " + Environment.CurrentDirectory + "\\" + inputPDFFile;
    Process proc = new Process();
    proc.StartInfo.FileName = ghostScriptPath;
    proc.StartInfo.Arguments = ars;
    proc.StartInfo.CreateNoWindow = true;
    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    proc.Start();
    proc.WaitForExit();
}
async Task GetFileFromMinio(string fileName)
{
    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
    var endpoint = "localhost:9000";
    var accessKey = "admin";
    var secretKey = "adminpassword";
    var bucketname = "testbucket";
    MemoryStream filestream = new MemoryStream();
    try
    {
        var minio = new MinioClient().WithEndpoint(endpoint).WithCredentials(accessKey, secretKey).Build();
        StatObjectArgs statObjectArgs = new StatObjectArgs()
            .WithBucket(bucketname)
            .WithObject(fileName);
        await minio.StatObjectAsync(statObjectArgs);

        GetObjectArgs getObjectArgs = new GetObjectArgs()
            .WithBucket(bucketname)
            .WithObject(fileName)
            .WithFile("./" + fileName);
        await minio.GetObjectAsync(getObjectArgs);
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

async void UpdateDatabaseAsync(string result, int id)
{
    var connectionString = "Host=host.docker.internal;Database=mydatabase;Username=myuser;Password=newpassword";
    await using var dataSource = NpgsqlDataSource.Create(connectionString);

    await using (var cmd = dataSource.CreateCommand("UPDATE \"Documents\" SET \"Content\" = ($1) WHERE \"Id\" = ($2)"))
    {
        cmd.Parameters.AddWithValue(result);
        cmd.Parameters.AddWithValue(id);
        await cmd.ExecuteNonQueryAsync();
    }
}

public class Document
{

    public int Id { get; set; }
    public int? Correspondent { get; set; }
    public int? DocumentType { get; set; }
    public int? StoragePath { get; set; }

    public string Title { get; set; }
    public string? Content { get; set; }
    public List<int> Tags { get; set; } = new List<int>();
    public byte[] Documentfile { get; set; }

    public DateTime? Created { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime Modified { get; set; }
    public DateTime Added { get; set; }
    public string? ArchiveSerialNumber { get; set; }

    public string? OriginalFileName { get; set; }

    public string? ArchivedFileName { get; set; }
}