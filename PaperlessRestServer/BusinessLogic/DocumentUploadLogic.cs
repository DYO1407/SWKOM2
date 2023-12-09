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

namespace BusinessLogic
{
    public class DocumentUploadLogic : IDocumentUploadLogic
    {
        
        
        //private readonly IDocumentRepository _documentRepository;
        //private readonly ITagRepository _tagRepository;
        private readonly IMessageLogic _messageLogic;
        private readonly IDManagementRepository _dManagementRepository;
        private readonly IMapper _mapper;
        public DocumentUploadLogic(IMessageLogic messageLogic, IDManagementRepository dmanagementRepository, IMapper mapper/*IDocumentRepository documentRepository, ITagRepository tagRepository*/)
        { 
            _messageLogic = messageLogic;
            _dManagementRepository = dmanagementRepository;
            _mapper = mapper;
            //_documentRepository = documentRepository;
            //_tagRepository = tagRepository;
        }

       
        public Document UploadDocument(Document doc)
        {


            var newDALDoc = _mapper.Map<DataAccess.Entities.Document>(doc);





            _dManagementRepository.AddDocument(newDALDoc);
            _messageLogic.SendingMessage<Document>(doc);
            //return _documentRepository.UploadDocumentAsync(document);
            return doc;
        }

        //Task<Document> UploadDocumentAsync(string title, DateTime? created, int? documentTypeId, List<int> tagIds, int? correspondentId, Stream documentStream)
        //{

        //}
    }
}
