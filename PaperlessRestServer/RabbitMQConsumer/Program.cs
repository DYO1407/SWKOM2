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
    var message = Encoding.UTF8.GetString(body);

    string input = Path.GetFileNameWithoutExtension(message);
    ProcessImage(input + ".pdf");

    var result = handleMessage(message);

    Console.WriteLine(result);
};

channel.BasicConsume("uploadDocument", true, consumer);

Console.ReadLine();

string handleMessage(string title)
{
    TesseractEngine engine = new TesseractEngine("./tessdata", "eng", EngineMode.Default);
    Page page = engine.Process(Pix.LoadFromMemory(File.ReadAllBytes(title.Replace("\"", "") + ".jpg")), PageSegMode.Auto);
    string result = page.GetText();
    return result;
}

void ProcessImage(string inputPDFFile)
{   
    var filename = Path.GetFileNameWithoutExtension(inputPDFFile);
    string ghostScriptPath = @"C:\Program Files\gs\gs10.02.1\bin\gswin64.exe";
    String ars = "-dNOPAUSE -sDEVICE=jpeg -r102.4 -o" + "C:\\Users\\deyaa\\source\\repos\\SWKOM2\\PaperlessRestServer\\RabbitMQConsumer\\" + filename + ".jpg -sPAPERSIZE=a4 " + "C:\\Users\\deyaa\\source\\repos\\SWKOM2\\PaperlessRestServer\\RabbitMQConsumer\\" + inputPDFFile;
    Process proc = new Process();
    proc.StartInfo.FileName = ghostScriptPath;
    proc.StartInfo.Arguments = ars;
    proc.StartInfo.CreateNoWindow = true;
    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    proc.Start();
    proc.WaitForExit();
}