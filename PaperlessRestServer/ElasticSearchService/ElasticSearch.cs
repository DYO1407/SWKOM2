using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Nest;

namespace ElasticSearchService
{
    public class ElasticSearch : IElasticSearch
    {

        private readonly Uri _uri;
        private readonly ILogger<ElasticSearch> _logger;
       

        public ElasticSearch(IConfiguration configuration, ILogger<ElasticSearch> logger)
        {
            this._uri = new Uri(configuration.GetConnectionString("ElasticSearch") ?? "http://localhost:9200/");

            
        
            this._logger = logger;

            
        }
        public void AddDocumentAsync(Document document)
        {
            var elasticClient = new ElasticsearchClient(_uri);

            if (!elasticClient.Indices.Exists("documents").Exists)
                elasticClient.Indices.Create("documents");

            var indexResponse = elasticClient.Index(document, "documents");
            if (!indexResponse.IsSuccess())
            {
                // Handle errors
                _logger.LogError($"Failed to index document: {indexResponse.DebugInformation}\n{indexResponse.ElasticsearchServerError}");

                throw new Exception($"Failed to index document: {indexResponse.DebugInformation}\n{indexResponse.ElasticsearchServerError}");
            }


        }

        public IEnumerable<Document> SearchDocumentAsync(string searchTerm)
        {
            var elasticClient = new ElasticsearchClient(_uri);

            var searchResponse = elasticClient.Search<Document>(s => s
                .Index("documents")
                .Query(q => q.QueryString(qs => qs.DefaultField(p => p.Content).Query($"*{searchTerm}*")))
            );

            return searchResponse.Documents;
        }



    }
}
