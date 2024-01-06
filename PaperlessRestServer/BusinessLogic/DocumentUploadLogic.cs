using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace BusinessLogic
{
    public class DocumentUploadLogic : IDocumentUploadLogic
    {
        
        
        //private readonly IDocumentRepository _documentRepository;
        //private readonly ITagRepository _tagRepository;
        private readonly IMessageLogic _messageLogic;
        private readonly IDManagementRepository _dManagementRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DocumentUploadLogic> _logger;
        public DocumentUploadLogic(IMessageLogic messageLogic, IDManagementRepository dmanagementRepository, IMapper mapper, ILogger<DocumentUploadLogic> logger/*IDocumentRepository documentRepository, ITagRepository tagRepository*/)
        { 
            _messageLogic = messageLogic;
            _dManagementRepository = dmanagementRepository;
            _mapper = mapper;
            _logger = logger;
            _logger.LogInformation("DocumentLogic initialized");
            //_documentRepository = documentRepository;
            //_tagRepository = tagRepository;
        }

       
        public Document UploadDocument(Document doc)
        {
            Document document = new Document();
            try
            {
                var newDALDoc = _mapper.Map<DataAccess.Entities.Document>(doc);
                document = _mapper.Map<BusinessLogic.Entities.Document>(_dManagementRepository.AddDocument(newDALDoc));
                _messageLogic.SendingMessage<Document>(document);
                _logger.LogInformation($"New Document { JsonSerializer.Serialize(document) }");
            }
            catch ( Exception ex )
            {
                _logger.LogError($"Uploading Document { JsonSerializer.Serialize(doc) }");
            }
            
            //return _documentRepository.UploadDocumentAsync(document);
            return document;
        }

        //Task<Document> UploadDocumentAsync(string title, DateTime? created, int? documentTypeId, List<int> tagIds, int? correspondentId, Stream documentStream)
        //{

        //}
    }
}
