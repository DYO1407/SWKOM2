using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Validators;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;
using Document = BusinessLogic.Entities.Document;
using DataAccess.Entities;
using FluentValidation;
using BusinessLogic.Interfaces;


namespace BusinessLogic
{
    public  class DocumentManagementLogic : IDocumentManagementLogic
    {

        private readonly IDManagementRepository _docRepository;
        private readonly IMapper _mapper;
        private readonly DocumentValidator _validator = new DocumentValidator();

        public DocumentManagementLogic(IDManagementRepository documentRepository, IMapper mapper)
        {
            _docRepository = documentRepository;
            _mapper = mapper;
            
        }

        public bool DeleteDocument(int id)
        {
            _docRepository.DeleteDocument(id);
            return true;
        }

        public Document GetDocument(int id)
        { 
            _docRepository.GetDocument(id);

            
            return new Document { Id = id };
        }

        public Document UpdateDocument(Document doc)
        {
            ValidateDocument(doc);
            _docRepository.UpdateDocument(_mapper.Map<DataAccess.Entities.Document>(doc));
            return doc;
        }

        private void ValidateDocument(Document document)
        {
            var validationResult = _validator.Validate(document);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}

