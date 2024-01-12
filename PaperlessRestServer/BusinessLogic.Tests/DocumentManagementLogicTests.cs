using System;
using AutoMapper;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using Microsoft.Extensions.Logging;
using DataAccess.Entities;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;
using BusinessLogic.Validators;
using BusinessLogic.Exceptions;
using DataAccess.Exceptions;

namespace BusinessLogic.Tests
{
    public class DocumentManagementLogicTests
    {
        private readonly Mock<IDManagementRepository> mockIdManagementRepo;
        private readonly Mock<IMapper> mockMapper;
        private readonly Mock<ILogger<DocumentManagementLogic>> mockLogger;
        private readonly DocumentManagementLogic _documentManagementLogic;
        private readonly Mock<ILogger<DocumentManagementLogic>> _mockLogger;
        private readonly DocumentValidator _documentValidator;

        public DocumentManagementLogicTests()
        {
            mockIdManagementRepo = new Mock<IDManagementRepository>();
            mockMapper = new Mock<IMapper>();
            mockLogger = new Mock<ILogger<DocumentManagementLogic>>();
            _documentManagementLogic = new DocumentManagementLogic(mockIdManagementRepo.Object, mockMapper.Object, mockLogger.Object);
            _documentValidator = new DocumentValidator();
        }

        [Fact]
        public void DeleteDocument_ShouldCallDeleteDocumentInRepository()
        {
            // Arrange
            int documentId = 1;

            // Act
            _documentManagementLogic.DeleteDocument(documentId);

            // Assert
            mockIdManagementRepo.Verify(repo => repo.DeleteDocument(documentId), Times.Once);
        }

        [Fact]
        public void GetDocument_ShouldCallGetDocumentInRepository()
        {
            // Arrange
            int documentId = 1;

            // Act
            _documentManagementLogic.GetDocument(documentId);

            // Assert
            mockIdManagementRepo.Verify(repo => repo.GetDocument(documentId), Times.Once);
        }

        [Fact]
        public void UpdateDocument_()
        {
            // Arrange
            var inputDocument = new BusinessLogic.Entities.Document
            {
                Id = 3,
                Title = "Title",
                Content = "Content",
                Tags = { 1, 2, 3 },
                Correspondent = 1,
                DocumentType = 2
            };

            var mappedDaDocument = new DataAccess.Entities.Document()
            {
                Id = inputDocument.Id,
                Title = inputDocument.Title,
                Content = inputDocument.Content,
                Tags = inputDocument.Tags,
                Correspondent = 1,
                DocumentType = 2
            };
            var returnedDaDocument = new DataAccess.Entities.Document()
            {
                Id = mappedDaDocument.Id,
                Title = mappedDaDocument.Title,
                Content = mappedDaDocument.Content,
                Tags = mappedDaDocument.Tags,
                Correspondent = 1,
                DocumentType = 2
            };
            var expectedDocument = new BusinessLogic.Entities.Document()
            {
                Id = 3,
                Title = "Title",
                Content = "Content",
                Tags = { 1, 2, 3 },
                Correspondent = 1,
                DocumentType = 2
            };

            mockMapper.Setup(m => m.Map<DataAccess.Entities.Document>(inputDocument)).Returns(mappedDaDocument);
            mockIdManagementRepo.Setup(r => r.UpdateDocument(mappedDaDocument)).Returns(returnedDaDocument);
            mockMapper.Setup(m => m.Map<BusinessLogic.Entities.Document>(returnedDaDocument)).Returns(expectedDocument);

            // Act
            var result = _documentManagementLogic.UpdateDocument(inputDocument);

            // Assert
            Assert.Equal(expectedDocument.Id, result.Id);

            // Verify that Map<Document> was called with the correct parameter
            mockMapper.Verify(m => m.Map<BusinessLogic.Entities.Document>(returnedDaDocument), Times.Once);
        }

        [Fact]
        public void UpdateDocument_notEqual()
        {
            // Arrange
            var inputDocument = new BusinessLogic.Entities.Document
            {
                Id = 2,
                Title = "Title",
                Content = "Content",
                Tags = { 1, 2, 3 },
                Correspondent = 1,
                DocumentType = 2
            };

            var mappedDaDocument = new DataAccess.Entities.Document()
            {
                Id = inputDocument.Id,
                Title = inputDocument.Title,
                Content = inputDocument.Content,
                Tags = inputDocument.Tags,
                Correspondent = 1,
                DocumentType = 2
            };
            var returnedDaDocument = new DataAccess.Entities.Document()
            {
                Id = mappedDaDocument.Id,
                Title = mappedDaDocument.Title,
                Content = mappedDaDocument.Content,
                Tags = mappedDaDocument.Tags,
                Correspondent = 1,
                DocumentType = 2
            };
            var expectedDocument = new BusinessLogic.Entities.Document()
            {
                Id = 3,
                Title = "Title",
                Content = "Content",
                Tags = { 1, 2, 3 },
                Correspondent = 1,
                DocumentType = 2
            };

            mockMapper.Setup(m => m.Map<DataAccess.Entities.Document>(inputDocument)).Returns(mappedDaDocument);
            mockIdManagementRepo.Setup(r => r.UpdateDocument(mappedDaDocument)).Returns(returnedDaDocument);
            mockMapper.Setup(m => m.Map<BusinessLogic.Entities.Document>(returnedDaDocument)).Returns(expectedDocument);

            // Act
            var result = _documentManagementLogic.UpdateDocument(inputDocument);

            // Assert
            Assert.NotEqual(expectedDocument.Id, result.Id);

            // Verify that Map<Document> was called with the correct parameter
            mockMapper.Verify(m => m.Map<BusinessLogic.Entities.Document>(returnedDaDocument), Times.Once);
        }

        [Fact]
        public void ValidateDocument_WithValidDocument_ShouldNotThrowException2()
        {
            // Arrange
            var document = new BusinessLogic.Entities.Document
            {
                Id = 3,
                Title = "Title",
                Content = "Content",
                Tags = { 1, 2, 3 },
                Correspondent = 1,
                DocumentType = 2
            };
            var validationResult = new FluentValidation.Results.ValidationResult(); // Assuming no errors for valid document
            _documentValidator.Validate(document);

            // Act & Assert
            var exception = Record.Exception(() => _documentManagementLogic.ValidateDocument(document));
            Assert.Null(exception);
        }
        [Fact]
        public void ValidateDocument_WithInvalidDocument_ShouldNotThrowException()
        {
            // Arrange
            var document = new BusinessLogic.Entities.Document
            {
         
                Title = "Title",
                Content = "Content",
                Tags = { 1, 2, 3 },
                Correspondent = 1,
                DocumentType = 2
            };
            var validationResult = new FluentValidation.Results.ValidationResult(); // Assuming no errors for valid document
           var result = _documentValidator.Validate(document);
            //_documentValidator.Validate(document);

            // Act & Assert
            //var exception = Record.Exception(() => _documentManagementLogic.ValidateDocument(document));
            Assert.NotEmpty(result.Errors);
            Assert.False(result.IsValid);
            Assert.Throws<FluentValidation.ValidationException>(() => _documentManagementLogic.ValidateDocument(document));
        }

        /*    [Fact]
            public void ValidateDocument_WithInvalidDocument_ShouldThrowValidationException()
            {
                // Arrange
                var document = new Document { };
                var validationResult = new ValidationResult(new List<ValidationFailure>
            {
                new ValidationFailure("Field", "Error message") // Assuming this is how your ValidationResult and ValidationFailure are structured
            });
                _mockValidator.Setup(v => v.Validate(document)).Returns(validationResult);

                // Act & Assert
                Assert.Throws<ValidationException>(() => _documentManagement.ValidateDocument(document));
            }
       */
        [Fact]
        public void DeleteDocument_ShouldCallDeleteDocumentInRepository2()
        {
            // Arrange
            int documentId = 1;

            // Act
            _documentManagementLogic.DeleteDocument(documentId);

            // Assert
            mockIdManagementRepo.Verify(repo => repo.DeleteDocument(documentId), Times.Once);
        }

        [Fact]
        public void GetDocument_ShouldCallGetDocumentInRepository2()
        {
            // Arrange
            int documentId = 1;

            // Act
            _documentManagementLogic.GetDocument(documentId);

            // Assert
            mockIdManagementRepo.Verify(repo => repo.GetDocument(documentId), Times.Once);
        }

        /*
       [Fact]
       public void DeleteDocument_DatabaseException_LogsErrorAndThrowsDataAccessException()
       {
           // Arrange
           int documentId = 1;

           mockIdManagementRepo.Setup(repo => repo.DeleteDocument(documentId)).Throws(new DatabaseException("Test Database Exception"));

           // Act & Assert
           var exception = Assert.Throws<DataAccessException>(() => _documentManagementLogic.DeleteDocument(documentId));

           // Verify logging
           mockLogger.Verify(logger => logger.LogError($"Document with ID: {documentId} could not be deleted"), Times.Once);

           // Verify exception details
           Assert.Equal("Error occurred while deleting document", exception.Message);
           Assert.IsType<DatabaseException>(exception.InnerException);
       }
       [Fact]
       public void DeleteDocument_DocumentNotFoundException_LogsWarningAndThrowsDocumentNotFoundException()
       {
           // Arrange
           int documentId = 1;

           mockIdManagementRepo.Setup(repo => repo.DeleteDocument(documentId))
                              .Throws(new DataAccess.Exceptions.DocumentNotFoundException("Test DocumentNotFoundException"));

           // Act & Assert
           var exception = Assert.Throws<DataAccessException>(() => _documentManagementLogic.DeleteDocument(documentId));

           // Verify logging
           mockLogger.Verify(logger => logger.LogWarning($"Document with ID: {documentId} does not exist", It.IsAny<Exception>()), Times.Once);

           // Verify exception details
           Assert.Equal("Error occurred while deleting document", exception.Message);
           Assert.IsType<DataAccess.Exceptions.DocumentNotFoundException>(exception.InnerException);
       }


              [Fact]
              public void UpdateDocument_InvalidInput_ShouldThrowDocumentNotFoundException()
              {
                  // Arrange
                  // ... (unchanged part)

                  // Act & Assert
                  Assert.Throws<BusinessLogic.Exceptions.DocumentNotFoundException>(() => _documentManagementLogic.UpdateDocument(inputDocument));
              }

              [Fact]
              public void UpdateDocument_ValidInput_ShouldReturnExpectedDocument()
              {
                  // Arrange
                  // ... (unchanged part)

                  // Act
                  var result = _documentManagementLogic.UpdateDocument(inputDocument);

                  // Assert
                  Assert.Equal(expectedDocument.Id, result.Id);
                  mockMapper.Verify(m => m.Map<BusinessLogic.Entities.Document>(returnedDaDocument), Times.Once);
              }


              [Fact]
              public void ValidateDocument_WithValidDocument_ShouldNotThrowException()
              {
                  // Arrange
                  var document = new BusinessLogic.Entities.Document
                  {
                      Id = 3,
                      Title = "Title",
                      Content = "Content",
                      Tags = { 1, 2, 3 },
                      Correspondent = 1,
                      DocumentType = 2
                  };

                  // Act & Assert
                  Assert.DoesNotThrow(() => _documentManagementLogic.ValidateDocument(document));
              }

              [Fact]
              public void ValidateDocument_WithInvalidDocument_ShouldThrowValidationException()
              {
                  // Arrange
                  var document = new BusinessLogic.Entities.Document
                  {
                      Title = "Title",
                      Content = "Content",
                      Tags = { 1, 2, 3 },
                      Correspondent = 1,
                      DocumentType = 2
                  };

                  // Act & Assert
                  Assert.Throws<ValidationException>(() => _documentManagementLogic.ValidateDocument(document));
              }*/

    }
}
