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

namespace BusinessLogic.Tests
{
    public class DocumentManagementLogicTests
    {
        private readonly Mock<IDManagementRepository> mockIdManagementRepo;
        private readonly Mock<IMapper> mockMapper;
        private readonly Mock<ILogger<DocumentManagementLogic>> mockLogger;
        private readonly DocumentManagementLogic _documentManagementLogic;
        private readonly Mock<ILogger<DocumentManagementLogic>> _mockLogger;   

        public DocumentManagementLogicTests()
        {
            mockIdManagementRepo = new Mock<IDManagementRepository>();
            mockMapper = new Mock<IMapper>();
            mockLogger = new Mock<ILogger<DocumentManagementLogic>>();
            _documentManagementLogic = new DocumentManagementLogic(mockIdManagementRepo.Object, mockMapper.Object, mockLogger.Object);
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

    }
}
