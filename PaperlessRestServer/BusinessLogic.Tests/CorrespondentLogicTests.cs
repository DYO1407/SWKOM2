using Xunit;
using BusinessLogic.Entities;
using FluentValidation;

namespace BusinessLogic.Tests
{
    public class CorrespondentLogicTests
    {

        public class CorrespondentServiceTests
        {
            [Fact]
            public void CreateCorrespondent_WithValidData_ReturnsCorrespondent()
            {
                // Arrange
                var CL = new CorrespondentLogic();
                var validCorrespondent = new Correspondent
                {
                    Id = 1,
                    Slug = "Slug",
                    Name = "owner",
                    DocumentCount = 1,
                    IsInsensitive = true,
                    Match = "m",
                    Matching_Algorithm = 1,
                    LastCorrespondence = DateTime.Now
                };

                // Act
                var result = CL.CreateCorrespondent(validCorrespondent);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(validCorrespondent.Id, result.Id);
                Assert.Equal(validCorrespondent, result);
            }


            [Fact]
            public void CreateCorrespondent_WithInvalidData_ThrowsValidationException()
            {
                // Arrange
                var CL = new CorrespondentLogic();
                var invalidCorrespondent = new Correspondent
                {
                    Id = 1,
                    //Slug = "Slug",
                    Name = "",
                    DocumentCount = 1,
                    IsInsensitive = true,
                    Match = "m",
                    Matching_Algorithm = 1,
                    LastCorrespondence = DateTime.Now
                };

                // Act & Assert
                Assert.Throws<ValidationException>(() => CL.CreateCorrespondent(invalidCorrespondent));
            }
        }


    }
}