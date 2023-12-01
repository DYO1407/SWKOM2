namespace BusinessLogic.Entities
{
    public class Correspondent
    {
        public long Id { get; set; }
        public string? Slug { get; set; }
        public string? Name { get; set; }
        public string? Match { get; set; }

        public long Matching_Algorithm { get; set; }
        public bool IsInsensitive { get; set; }
        public long DocumentCount { get; set; }

        public DateTime? LastCorrespondence { get; set; }
    }
}