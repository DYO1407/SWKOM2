using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace ElasticSearchService
{
    public class ElasticSearch : IElasticSearch
    {
        public void AddDocumentAsync(Document doc)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Document> SearchDocumentAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
