using DataAccess.Exceptions;
using System;
using Xunit;

namespace DataAccess.Tests.Exceptions
{
    public class DatabaseExceptionTests
    {
  

        [Fact]
        public void ConstructorWithMessage_SetsMessage()
        {
            // Arrange
            string expectedMessage = "Test Message";

            // Act
            var exception = new DatabaseException(expectedMessage);

            // Assert
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void ConstructorWithMessageAndInnerException_SetsMessageAndInnerException()
        {
            // Arrange
            string expectedMessage = "Test Message";
            var innerException = new Exception("Inner Exception");

            // Act
            var exception = new DatabaseException(expectedMessage, innerException);

            // Assert
            Assert.Equal(expectedMessage, exception.Message);
            Assert.Same(innerException, exception.InnerException);
        }

  
    }
}
