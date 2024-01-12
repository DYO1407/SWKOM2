namespace ElasticSearchService
{
    public interface IElasticSearch
    {
        void AddDocumentAsync(Document doc);
        IEnumerable<Document> SearchDocumentAsync(string searchTerm);

    }
}
