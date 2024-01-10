using System;
using AutoMapper;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using FluentValidation;
using Moq;
using Xunit;
using Microsoft.Extensions.Logging;

namespace BusinessLogic.Tests
{
    public class DocumentManagementLogicTests
    {
        private readonly Mock<IDManagementRepository> _mockDocRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly DocumentManagementLogic _documentManagementLogic;
        private readonly Mock<ILogger<DocumentManagementLogic>> _mockLogger;   

        public DocumentManagementLogicTests()
        {
            _mockDocRepository = new Mock<IDManagementRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<DocumentManagementLogic>>();
            _documentManagementLogic = new DocumentManagementLogic(_mockDocRepository.Object, _mockMapper.Object, _mockLogger.Object);
        }

        [Fact]
        public void DeleteDocument_ShouldCallDeleteDocumentInRepository()
        {
            // Arrange
            int documentId = 1;

            // Act
            _documentManagementLogic.DeleteDocument(documentId);

            // Assert
            _mockDocRepository.Verify(repo => repo.DeleteDocument(documentId), Times.Once);
        }

        [Fact]
        public void GetDocument_ShouldCallGetDocumentInRepository()
        {
            // Arrange
            int documentId = 1;

            // Act
            _documentManagementLogic.GetDocument(documentId);

            // Assert
            _mockDocRepository.Verify(repo => repo.GetDocument(documentId), Times.Once);
        }


        [Fact]
        public void UpdateDocument_InvalidDocument_ShouldThrowValidationException()
        {
            // Arrange
            var invalidDocument = new Document(); // Assuming this document is invalid
            _mockMapper.Setup(mapper => mapper.Map<DataAccess.Entities.Document>(invalidDocument))
                       .Returns(new DataAccess.Entities.Document());

            // Act & Assert
            Assert.Throws<ValidationException>(() => _documentManagementLogic.UpdateDocument(invalidDocument));
        }
    }
}
