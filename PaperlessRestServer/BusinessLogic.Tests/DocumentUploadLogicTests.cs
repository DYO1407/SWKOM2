using Xunit;
using BusinessLogic.Entities;
using FluentValidation;
using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using AutoMapper;
using Moq;

namespace BusinessLogic.Tests
{
        public class DocumentUploadLogicTests
        {
            [Fact]
            public void UploadDocument_WithValidDocument_CallsRepositoryAddDocumentAndMessageLogic()
            {
                // Arrange
                var mockMessageLogic = new Mock<IMessageLogic>();
                var mockDManagementRepository = new Mock<IDManagementRepository>();
                var mockMapper = new Mock<IMapper>();

                var logic = new DocumentUploadLogic(mockMessageLogic.Object, mockDManagementRepository.Object, mockMapper.Object);
                var validDocument = new Document
                {
                    Title = "Test Document",
                    // Other properties...
                };

                // Act
                logic.UploadDocument(validDocument);

                // Assert
                mockDManagementRepository.Verify(repo => repo.AddDocument(It.IsAny<DataAccess.Entities.Document>()), Times.Once);
                mockMessageLogic.Verify(messageLogic => messageLogic.SendingMessage<String>(It.IsAny<string>()), Times.Once);
            }
    }
}
