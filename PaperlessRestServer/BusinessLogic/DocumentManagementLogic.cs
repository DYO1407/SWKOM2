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
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Text.Json;
using DataAccess.Exceptions;
using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public  class DocumentManagementLogic : IDocumentManagementLogic
    {

        private readonly IDManagementRepository _docRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DocumentManagementLogic> _logger;
        private readonly DocumentValidator _validator = new DocumentValidator();

        public DocumentManagementLogic(IDManagementRepository documentRepository, IMapper mapper, ILogger<DocumentManagementLogic> logger)
        {
            _docRepository = documentRepository;
            _mapper = mapper;
            _logger = logger;
            _logger.LogInformation("DocumentManagementLogic inizialized");
        }

        public bool DeleteDocument(int id)
        {
            try
            {
                _docRepository.DeleteDocument(id);
                _logger.LogInformation($"Document with ID: {id} successfully deleted");
            }
            catch(DatabaseException ex)
            {
                _logger.LogError($"Document with ID: {id} could not be deleted");
                throw new DataAccessException("Error occured while deleting document", ex);
            }
            catch(DataAccess.Exceptions.DocumentNotFoundException ex)
            {
                _logger.LogWarning($"Document with ID: {id} does not exist", ex);
                throw new BusinessLogic.Exceptions.DocumentNotFoundException();
            }
            return true;
        }

        public Document GetDocument(int id)
        {
            Document document = new Document();
            try 
            {
                document = _mapper.Map<BusinessLogic.Entities.Document>(_docRepository.GetDocument(id));
                _logger.LogInformation($"Found Document { JsonSerializer.Serialize(document) }");
            }
            catch (DataAccess.Exceptions.DocumentNotFoundException ex)
            {
                _logger.LogWarning($"No Document with ID {id} found");
                throw new BusinessLogic.Exceptions.DocumentNotFoundException();
            }
            catch(DatabaseException ex)
            {
                _logger.LogError($"Document with ID {id} could not be fetched");
                throw new DataAccessException("Fetch document failed", ex);
            }
            return document;
        }

        public Document UpdateDocument(Document doc)
        {
            Document document = new Document();
            try
            {
                ValidateDocument(doc);
                DataAccess.Entities.Document DADoc = _docRepository.UpdateDocument(_mapper.Map<DataAccess.Entities.Document>(doc));
                document = _mapper.Map<BusinessLogic.Entities.Document>(DADoc);
                _logger.LogInformation($"Document updated: {document}");
            }
            catch(DataAccess.Exceptions.DocumentNotFoundException ex)
            {
                _logger.LogError($"Document {JsonSerializer.Serialize(doc) } could not be updated");
                throw new BusinessLogic.Exceptions.DocumentNotFoundException("Document could not be found", ex);
            }
            return doc;
        }

        public void ValidateDocument(Document document)
        {
            var validationResult = _validator.Validate(document);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}

