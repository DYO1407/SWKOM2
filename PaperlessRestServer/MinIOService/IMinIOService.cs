using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinIOFileStorageService
{
    public interface IMinIOService
    {
        Task UploadFileAsync(Stream fileStream,string contentType ,string filename);


    }
}
