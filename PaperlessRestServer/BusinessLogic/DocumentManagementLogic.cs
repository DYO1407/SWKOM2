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
            catch (Exception ex)
            {
                _logger.LogError($"Document with ID: {id} could not be deleted");
                
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
            catch (Exception ex)
            {
                _logger.LogError($"No Document with ID {id} found");
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
            catch(ValidationException ex)
            {
                _logger.LogError("Validation failed");
            }
            catch(Exception ex)
            {
                _logger.LogError($"Document {JsonSerializer.Serialize(doc) } could not be updated");
            }
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

