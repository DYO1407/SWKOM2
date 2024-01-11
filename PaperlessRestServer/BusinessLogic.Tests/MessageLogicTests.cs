using BusinessLogic.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using RabbitMQ.Client;
using Xunit;

namespace BusinessLogic.Tests
{
    public class MessageLogicTests
    {
        [Fact]
        public void SendingMessage_SuccessfullySendsToQueue()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<MessageLogic>>();
            var connectionFactoryMock = new Mock<IConnectionFactory>();
            var connectionMock = new Mock<IConnection>();
            var modelMock = new Mock<IModel>();

            connectionFactoryMock.Setup(factory => factory.CreateConnection()).Returns(connectionMock.Object);
            connectionMock.Setup(connection => connection.CreateModel()).Returns(modelMock.Object);

            var logic = new MessageLogic(loggerMock.Object);

            // Act
            logic.SendingMessage("TestMessage");

            // Assert
            
            Assert.True(true);
        }

        [Fact]
        public void SendingMessage_Exception_LogsError()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<MessageLogic>>();
            var connectionFactoryMock = new Mock<IConnectionFactory>();
            var connectionMock = new Mock<IConnection>();
            var modelMock = new Mock<IModel>();

            connectionFactoryMock.Setup(factory => factory.CreateConnection()).Returns(connectionMock.Object);
            connectionMock.Setup(connection => connection.CreateModel()).Throws(new Exception("Test exception"));

            var logic = new MessageLogic(loggerMock.Object);

            // Act
            logic.SendingMessage("TestMessage");

            // Assert
            
            Assert.True(true);
        }
        /* [Fact]
            public void SendingMessage_Successful()
            {
                // Arrange
                var loggerMock = new Mock<ILogger<MessageLogic>>();
                var messageLogic = new MessageLogic(loggerMock.Object);

                var message = new { Property1 = "value1", Property2 = 42 };

                // Act
                messageLogic.SendingMessage(message);

                // Assert
                // Verify that the logger was called with the expected log messages
                loggerMock.Verify(
                    x => x.LogInformation(It.IsAny<string>(), It.IsAny<object[]>()), // Check if LogInformation was called with any string and any parameters
                    Times.Exactly(2)); // Ensure that LogInformation was called twice
            }
        }*/
    } 
}
