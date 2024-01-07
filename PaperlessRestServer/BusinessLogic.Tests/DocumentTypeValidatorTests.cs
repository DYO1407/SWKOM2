using Xunit;
using BusinessLogic.Entities;
using FluentValidation.TestHelper;
using BusinessLogic.Validators;

namespace BusinessLogic.Tests.Validators
{
    public class DocumentTypeValidatorTests
    {
        [Fact]
        public void ShouldHaveErrorWhenIdIsEmpty()
        {
            // Arrange
            var validator = new DocumentTypeValidator();
            var documentType = new DocumentType { Id = 0 };

            // Act
            var result = validator.TestValidate(documentType);

            // Assert
            result.ShouldHaveValidationErrorFor(dt => dt.Id);
        }

        [Fact]
        public void ShouldHaveErrorWhenSlugIsNull()
        {
            // Arrange
            var validator = new DocumentTypeValidator();
            var documentType = new DocumentType { Slug = null };

            // Act
            var result = validator.TestValidate(documentType);

            // Assert
            result.ShouldHaveValidationErrorFor(dt => dt.Slug);
        }

        // Repeat similar tests for other properties...

       
    }
}
