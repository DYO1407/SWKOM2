using Minio;
using Minio.DataModel.Args;

using Minio.Exceptions;
using System;
using System.Threading.Tasks;


namespace MinIOFileStorageService
{
    public class MinIOService : IMinIOService
    {
        private readonly IMinioClient _minioclient;
        private readonly string _bucketname;

        public MinIOService(string bucketname ,string endpoint,string accesskey, string secretKey)

        {
            _minioclient = new MinioClient().WithEndpoint(endpoint).WithCredentials(accesskey, secretKey).Build();
            _bucketname = bucketname;
            

        }


        public async Task UploadFileAsync(Stream fileStream, string contentType, string filename)
        {

            var beArgs = new BucketExistsArgs()
                     .WithBucket(_bucketname);
            bool found = await _minioclient.BucketExistsAsync(beArgs).ConfigureAwait(false);
            if (!found)
            {
                var mbArgs = new MakeBucketArgs()
                    .WithBucket(_bucketname);
                await _minioclient.MakeBucketAsync(mbArgs).ConfigureAwait(false);
            }
            try
                {
                PutObjectArgs putObjectArgs = new PutObjectArgs()
                    .WithBucket(_bucketname)
                    .WithObject(filename)
                    .WithStreamData(fileStream)
                    .WithContentType(contentType)
                  
                    
                    .WithObjectSize(fileStream.Length);
                
         

                // Datei hochladen
                await _minioclient.PutObjectAsync(putObjectArgs);
                Console.WriteLine("Datei erfolgreich hochgeladen.");
            }
            catch (MinioException e)
            {
                Console.WriteLine($"Fehler beim Hochladen der Datei: {e.Message}");
            }
        }
    }



}
