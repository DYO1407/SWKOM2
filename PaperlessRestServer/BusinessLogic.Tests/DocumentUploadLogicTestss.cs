using BusinessLogic;
using BusinessLogic.Entities;
using DataAccess.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using AutoMapper;
using System;
using Xunit;
using BusinessLogic.Interfaces;


public class DocumentUploadLogicTests
{
    private readonly Mock<IMessageLogic> _messageLogicMock;
    private readonly Mock<IDManagementRepository> _dManagementRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<ILogger<DocumentUploadLogic>> _loggerMock;

    public DocumentUploadLogicTests()
    {
        // Arrange: Initialize mocks for dependencies
        _messageLogicMock = new Mock<IMessageLogic>();
        _dManagementRepositoryMock = new Mock<IDManagementRepository>();
        _mapperMock = new Mock<IMapper>();
        _loggerMock = new Mock<ILogger<DocumentUploadLogic>>();
    }

    [Fact]
    public void UploadDocument_Success()
    {
        // Arrange
        var messageLogicMock = new Mock<IMessageLogic>();
        var dManagementRepositoryMock = new Mock<IDManagementRepository>();
        var mapperMock = new Mock<IMapper>();
        var loggerMock = new Mock<ILogger<DocumentUploadLogic>>();

        var documentToUpload = new BusinessLogic.Entities.Document();
        var dalDocument = new DataAccess.Entities.Document();
        var mappedDocument = new BusinessLogic.Entities.Document();

        messageLogicMock.Setup(m => m.SendingMessage<Document>(It.IsAny<Document>()));
        dManagementRepositoryMock.Setup(repo => repo.AddDocument(It.IsAny<DataAccess.Entities.Document>())).Returns(dalDocument);
        mapperMock.Setup(m => m.Map<DataAccess.Entities.Document>(It.IsAny<Document>())).Returns(dalDocument);
        mapperMock.Setup(m => m.Map<BusinessLogic.Entities.Document>(It.IsAny<DataAccess.Entities.Document>())).Returns(mappedDocument);

        var documentUploadLogic = new DocumentUploadLogic(messageLogicMock.Object, dManagementRepositoryMock.Object, mapperMock.Object, loggerMock.Object);

        // Act
        var result = documentUploadLogic.UploadDocument(documentToUpload);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(mappedDocument, result);

        //messageLogicMock.Verify(m => m.SendingMessage<Document>(It.IsAny<Document>()), Times.Once);
       // dManagementRepositoryMock.Verify(repo => repo.AddDocument(It.IsAny<DataAccess.Entities.Document>()), Times.Once);
        //loggerMock.Verify(logger => logger.LogInformation(It.IsAny<string>()), Times.Once);
        // Adjust the setup to match the log message
        //loggerMock.Verify(logger => logger.LogInformation(It.Is<string>(msg => msg.Contains("New Document")), Times.Once));

    }

 /*   [Fact]
    public void UploadDocument_Exception()
    {
        // Arrange
        var messageLogicMock = new Mock<IMessageLogic>();
        var dManagementRepositoryMock = new Mock<IDManagementRepository>();
        var mapperMock = new Mock<IMapper>();
        var loggerMock = new Mock<ILogger<DocumentUploadLogic>>();

        var documentToUpload = new BusinessLogic.Entities.Document();
        var exceptionMessage = "Simulating an exception";

        messageLogicMock.Setup(m => m.SendingMessage<Document>(It.IsAny<Document>()));
        dManagementRepositoryMock.Setup(repo => repo.AddDocument(It.IsAny<DataAccess.Entities.Document>())).Throws(new Exception(exceptionMessage));
        mapperMock.Setup(m => m.Map<DataAccess.Entities.Document>(It.IsAny<Document>())).Returns(new DataAccess.Entities.Document());

        var documentUploadLogic = new DocumentUploadLogic(messageLogicMock.Object, dManagementRepositoryMock.Object, mapperMock.Object, loggerMock.Object);

        // Act
        var result = documentUploadLogic.UploadDocument(documentToUpload);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(default(BusinessLogic.Entities.Document), result);

        messageLogicMock.Verify(m => m.SendingMessage<Document>(It.IsAny<Document>()), Times.Never);
        dManagementRepositoryMock.Verify(repo => repo.AddDocument(It.IsAny<DataAccess.Entities.Document>()), Times.Once);
        loggerMock.Verify(logger => logger.LogError(It.IsAny<string>()), Times.Once);
    }*/
}
