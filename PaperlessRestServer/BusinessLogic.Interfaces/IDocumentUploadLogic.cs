using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IDocumentUploadLogic
    {
        Task<Document> UploadDocumentAsync(string title, DateTime? created, int? documentTypeId, List<int> tagIds, int? correspondentId, Stream documentStream);
    }
}
