using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{

    [Table("Documents")]
    public  class Document
    {
        [Key]
        public long Id { get; set; }
        public Correspondent? Correspondent { get; set; }
        public DocumentType? DocumentType { get; set; }
        public long? StoragePath { get; set; }

        public string? Title { get; set; }
        public string? Content { get; set; }
        public List<string> Tags { get; set; } = new List<string>();

        public DateTime Created { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Added { get; set; }
        public string? ArchiveSerialNumber { get; set; }

        public string? OriginalFileName { get; set; }

        public string? ArchivedFileName { get; set; }

    }
}
