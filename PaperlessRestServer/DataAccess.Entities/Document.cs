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
        public int Id { get; set; }
        public int Correspondent { get; set; }
        public int DocumentType { get; set; }
        public int? StoragePath { get; set; }

        public string? Title { get; set; }
        public string? Content { get; set; }
        public List<int> Tags { get; set; } = new List<int>();
        public byte[] Documentfile { get; set; }
        public DateTime Created { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Added { get; set; }
        public string? ArchiveSerialNumber { get; set; }

        public string? OriginalFileName { get; set; }

        public string? ArchivedFileName { get; set; }

    }
}
