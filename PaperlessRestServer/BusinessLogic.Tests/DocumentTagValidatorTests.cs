using Xunit;
using BusinessLogic.Entities;
using FluentValidation.TestHelper;
using Moq;
using BusinessLogic.Validators;

namespace BusinessLogic.Tests
{
    public class DocumentTagValidatorTests
    {
        [Fact]
        public void ShouldHaveErrorWhenIdIsEmpty()
        {
            // Arrange
            var validator = new DocumentTagValidator();
            var documentTag = new DocumentTag { Id = 0 };

            // Act
            var result = validator.TestValidate(documentTag);

            // Assert
            result.ShouldHaveValidationErrorFor(t => t.Id);
        }

        [Fact]
        public void ShouldHaveErrorWhenSlugIsNull()
        {
            // Arrange
            var validator = new DocumentTagValidator();
            var documentTag = new DocumentTag { Slug = null };

            // Act
            var result = validator.TestValidate(documentTag);

            // Assert
            result.ShouldHaveValidationErrorFor(t => t.Slug);
        }


      
    }
}
