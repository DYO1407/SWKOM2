using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    [Table("DocumentTags")]
    public class DocumentTag
    {
        [Key]
        public int Id { get; set; }

        public string? Slug { get; set; }

        public string? Name { get; set; }

        public string? Color { get; set; }

        public string? Match { get; set; }

        public int MatchingAlgorithm { get; set; }

        public bool IsInsensitive { get; set; }

        public bool IsInboxTag { get; set; }

        public int DocumentCount { get; set; }
    }
}
