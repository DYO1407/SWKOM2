using Xunit;
using BusinessLogic.Entities;
using FluentValidation;
using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using AutoMapper;
using Moq;

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
                var mockRepo = new Mock<ICorrespondentRepository>();
                var mockMapper = new Mock<IMapper>();

                mockRepo.Setup(repo =>repo.AddCorrespondent(It.IsAny<DataAccess.Entities.Correspondent>()));
                mockMapper.Setup(mapper => mapper.Map<DataAccess.Entities.Correspondent>(It.IsAny<Correspondent>()))
                .Returns(new DataAccess.Entities.Correspondent());

                var CL = new CorrespondentLogic(mockRepo.Object,mockMapper.Object);
                var validCorrespondent = new Correspondent
                {
                    Id = 1,
                    Slug = "Slug",
                    Name = "owner",
                    DocumentCount = 1,
                    IsInsensitive = true,
                    Match = "m",
                    Matching_Algorithm = 0,
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
                var mockRepo = new Mock<ICorrespondentRepository>();
                var mockMapper = new Mock<IMapper>();

                mockRepo.Setup(repo => repo.AddCorrespondent(It.IsAny<DataAccess.Entities.Correspondent>()));
                mockMapper.Setup(mapper => mapper.Map<DataAccess.Entities.Correspondent>(It.IsAny<Correspondent>()))
                .Returns(new DataAccess.Entities.Correspondent());


                var CL = new CorrespondentLogic(mockRepo.Object, mockMapper.Object);
                var invalidCorrespondent = new Correspondent
                {
                    Id = 1,
                    //Slug = "Slug",
                    Name = "",
                    DocumentCount = 1,
                    IsInsensitive = true,
                    Match = "m",
                    Matching_Algorithm = 0,
                    LastCorrespondence = DateTime.Now
                };

                // Act & Assert
                Assert.Throws<ValidationException>(() => CL.CreateCorrespondent(invalidCorrespondent));
            }
        }


    }
}