using DataAccess.Exceptions;
using System;
using Xunit;

namespace DataAccess.Tests.Exceptions
{
    public class CorrespondentNotFoundExceptionTests
    {
       
            [Fact]
            public void DefaultConstructor_ShouldCreateInstance()
            {
                // Act
                var exception = new CorrespondentNotFoundException();

                // Assert
                Assert.NotNull(exception);
                Assert.IsType<CorrespondentNotFoundException>(exception);
            }

            [Fact]
            public void ConstructorWithMessage_ShouldSetMessage()
            {
                // Arrange
                var expectedMessage = "Test Message";

                // Act
                var exception = new CorrespondentNotFoundException(expectedMessage);

                // Assert
                Assert.Equal(expectedMessage, exception.Message);
            }

            [Fact]
            public void ConstructorWithMessageAndInnerException_ShouldSetMessageAndInnerException()
            {
                // Arrange
                var expectedMessage = "Test Message";
                var innerException = new Exception("Inner Exception");

                // Act
                var exception = new CorrespondentNotFoundException(expectedMessage, innerException);

                // Assert
                Assert.Equal(expectedMessage, exception.Message);
                Assert.Same(innerException, exception.InnerException);
            }

            [Fact]
            public void ConstructorWithMessage_SetsMessage()
            {
                // Arrange
                string expectedMessage = "Test Message";

                // Act
                var exception = new CorrespondentNotFoundException(expectedMessage);

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
                var exception = new CorrespondentNotFoundException(expectedMessage, innerException);

                // Assert
                Assert.Equal(expectedMessage, exception.Message);
                Assert.Same(innerException, exception.InnerException);
            }



      
    }
}
