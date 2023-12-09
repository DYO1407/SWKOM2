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
        public int Id { get; set; }
        public string? Slug { get; set; }
        public string? Name { get; set; }

        public string? Match { get; set; }
        public int? MatchingAlgorithm { get; set; }

        public bool IsInsensitive { get; set; }
        public int DocumentCount { get; set; }

        public int owner { get; set; }

        public bool user_can_change { get; set; }
    }
}
