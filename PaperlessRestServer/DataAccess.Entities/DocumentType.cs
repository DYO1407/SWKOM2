using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    [Table("DocumentType")]
    public class DocumentType
    {
        [Key]
        public Int64 Id { get; set; }
        public string? Slug { get; set; }
        public string? Name { get; set; }

        public string? Match { get; set; }
        public Int64? MatchingAlgorithm { get; set; }

        public bool IsInsensitive { get; set; }
        public Int64 DocumentCount { get; set; }
    }
}
