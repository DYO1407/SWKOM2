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
        private readonly ICorrespondentRepository _correspondentRepository;
        private readonly IMapper _mapper;
        public DocumentUploadLogic(IMessageLogic messageLogic, ICorrespondentRepository correspondentRepository, IMapper mapper/*IDocumentRepository documentRepository, ITagRepository tagRepository*/)
        { 
            _messageLogic = messageLogic;
            _correspondentRepository = correspondentRepository;
            _mapper = mapper;
            //_documentRepository = documentRepository;
            //_tagRepository = tagRepository;
        }

       
        public Document UploadDocument(string title, DateTime? created, int? documentTypeId, List<int> tagIds, int? correspondentId/*, Stream documentStream*/)
        {
            //var streamReader = new StreamReader(documentStream);
            //var documentContent = streamReader.ReadToEnd();
            List<string> tagList = new List<string>();
            tagList.Add(tagIds[0].ToString());
            Correspondent Correspondent = _mapper.Map<BusinessLogic.Entities.Correspondent>(_correspondentRepository.GetCorrespondent((int)correspondentId));

            var document = new BusinessLogic.Entities.Document
            {
                Title = title,
                //Content = documentContent,
                CreatedDate = (DateTime)created,
                Tags = tagList,
                Correspondent = Correspondent
            };

            _messageLogic.SendingMessage<Document>(document);
            //return _documentRepository.UploadDocumentAsync(document);
            return document;
        }

        //Task<Document> UploadDocumentAsync(string title, DateTime? created, int? documentTypeId, List<int> tagIds, int? correspondentId, Stream documentStream)
        //{

        //}
    }
}
