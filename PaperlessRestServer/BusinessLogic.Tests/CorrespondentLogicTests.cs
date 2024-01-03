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
        //CorrespondentLogic Klasse testen
        //nur CreateCorrespondent getestet

        //rest noch testen
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

            [Fact]
            public void UpdateCorrespondent_WithValidData_ReturnsCorrespondent()
            {
                // Arrange
                var mockRepo = new Mock<ICorrespondentRepository>();
                var mockMapper = new Mock<IMapper>();
                
                mockRepo.Setup(repo => repo.AddCorrespondent(It.IsAny<DataAccess.Entities.Correspondent>()));
                mockMapper.Setup(mapper => mapper.Map<DataAccess.Entities.Correspondent>(It.IsAny<Correspondent>()))
                .Returns(new DataAccess.Entities.Correspondent());

                var CL = new CorrespondentLogic(mockRepo.Object, mockMapper.Object);
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
                var result = CL.UpdateCorrespondent(validCorrespondent);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(validCorrespondent.Id, result.Id);
                Assert.Equal(validCorrespondent, result);
            }

            [Fact]
            public void DeleteCorrespondent_WithValidId_ReturnsTrue()
            {
                // Arrange
                var mockRepo = new Mock<ICorrespondentRepository>();
                var mockMapper = new Mock<IMapper>();

                var CL = new CorrespondentLogic(mockRepo.Object, mockMapper.Object);
                var validId = 1;

                // Act
                var result = CL.DeleteCorrespondent(validId);

                // Assert
                Assert.True(result);
                // Add more assertions if needed
            }
            [Fact]
            public void CreateCorrespondent_WithValidData_CallsRepositoryAddMethod()
            {
                // Arrange
                var mockRepo = new Mock<ICorrespondentRepository>();
                var mockMapper = new Mock<IMapper>();

                var CL = new CorrespondentLogic(mockRepo.Object, mockMapper.Object);
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
                CL.CreateCorrespondent(validCorrespondent);

                // Assert
                mockRepo.Verify(repo => repo.AddCorrespondent(It.IsAny<DataAccess.Entities.Correspondent>()), Times.Once);
            }

            [Fact]
            public void UpdateCorrespondent_WithInvalidData_ThrowsValidationException()
            {
                // Arrange
                var mockRepo = new Mock<ICorrespondentRepository>();
                var mockMapper = new Mock<IMapper>();

                var CL = new CorrespondentLogic(mockRepo.Object, mockMapper.Object);
                var invalidCorrespondent = new Correspondent
                {
                    Id = 1,
                    Slug = "Slug",
                    Name = "", // Invalid data
                    DocumentCount = 1,
                    IsInsensitive = true,
                    Match = "m",
                    Matching_Algorithm = 0,
                    LastCorrespondence = DateTime.Now
                };

                // Act & Assert
                Assert.Throws<ValidationException>(() => CL.UpdateCorrespondent(invalidCorrespondent));
            }

            [Fact]
            public void GetCorrespondent_WithInvalidPage_ReturnsNull()
            {
                // Arrange
                var mockRepo = new Mock<ICorrespondentRepository>();
                var mockMapper = new Mock<IMapper>();

                mockRepo.Setup(repo => repo.GetCorrespondent(It.IsAny<int>()))
                    .Returns((DataAccess.Entities.Correspondent)null); // Simulate a null result from the repository

                var CL = new CorrespondentLogic(mockRepo.Object, mockMapper.Object);
                var invalidPage = -1; // Invalid page

                // Act
                var result = CL.GetCorrespondent(invalidPage);

                // Assert
                Assert.Null(result);
            }

            [Fact]
            public void DeleteCorrespondent_WithInnvalidId_ReturnsTrue()
            {
                // Arrange
                var mockRepo = new Mock<ICorrespondentRepository>();
                var mockMapper = new Mock<IMapper>();

                var CL = new CorrespondentLogic(mockRepo.Object, mockMapper.Object);
                var invalidId = -1; // Invalid id

                // Act
                var result = CL.DeleteCorrespondent(invalidId);

                // Assert
                Assert.True(result);
                // Add more assertions if needed
            }

            

            [Fact]
            public void UpdateCorrespondent_WithVaalidData_CallsRepositoryUpdateMethod()
            {
                // Arrange
                var mockRepo = new Mock<ICorrespondentRepository>();
                var mockMapper = new Mock<IMapper>();

                mockRepo.Setup(repo => repo.UpdateCorrespondent(It.IsAny<DataAccess.Entities.Correspondent>()));

                var CL = new CorrespondentLogic(mockRepo.Object, mockMapper.Object);
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
                CL.UpdateCorrespondent(validCorrespondent);

                // Assert
                mockRepo.Verify(repo => repo.UpdateCorrespondent(It.IsAny<DataAccess.Entities.Correspondent>()), Times.Once);
            }
            [Fact]
            public void CreateCorrespondent_WithNullCorrespondent_ThrowsArgumentNullException()
            {
                // Arrange
                var mockRepo = new Mock<ICorrespondentRepository>();
                var mockMapper = new Mock<IMapper>();

                var CL = new CorrespondentLogic(mockRepo.Object, mockMapper.Object);

                // Act & Assert
                Assert.Throws<ArgumentNullException>(() => CL.CreateCorrespondent(null));
            }

            [Fact]
            public void CreateCorrespondent_WithValidData_CallsMapperMapMethod()
            {
                // Arrange
                var mockRepo = new Mock<ICorrespondentRepository>();
                var mockMapper = new Mock<IMapper>();

                mockRepo.Setup(repo => repo.AddCorrespondent(It.IsAny<DataAccess.Entities.Correspondent>()));
                mockMapper.Setup(mapper => mapper.Map<DataAccess.Entities.Correspondent>(It.IsAny<Correspondent>()))
                    .Returns(new DataAccess.Entities.Correspondent());

                var CL = new CorrespondentLogic(mockRepo.Object, mockMapper.Object);
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
                CL.CreateCorrespondent(validCorrespondent);

                // Assert
                mockMapper.Verify(mapper => mapper.Map<DataAccess.Entities.Correspondent>(It.IsAny<Correspondent>()), Times.Once);
            }

           

        
            [Fact]
            public void UpdateCorrespondent_WithNullCorrespondent_ThrowsArgumentNullException()
            {
                // Arrange
                var mockRepo = new Mock<ICorrespondentRepository>();
                var mockMapper = new Mock<IMapper>();

                var CL = new CorrespondentLogic(mockRepo.Object, mockMapper.Object);

                // Act & Assert
                Assert.Throws<ArgumentNullException>(() => CL.UpdateCorrespondent(null));
            }

            [Fact]
            public void UpdateCorrespondent_WithValidData_CallsMapperMapMethod()
            {
                // Arrange
                var mockRepo = new Mock<ICorrespondentRepository>();
                var mockMapper = new Mock<IMapper>();

                mockRepo.Setup(repo => repo.UpdateCorrespondent(It.IsAny<DataAccess.Entities.Correspondent>()));
                mockMapper.Setup(mapper => mapper.Map<DataAccess.Entities.Correspondent>(It.IsAny<Correspondent>()))
                    .Returns(new DataAccess.Entities.Correspondent());

                var CL = new CorrespondentLogic(mockRepo.Object, mockMapper.Object);
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
                CL.UpdateCorrespondent(validCorrespondent);

                // Assert
                mockMapper.Verify(mapper => mapper.Map<DataAccess.Entities.Correspondent>(It.IsAny<Correspondent>()), Times.Once);
            }

            [Fact]
            public void UpdateCorrespondent_WithValidData_CallsRepositoryUpdateMethod()
            {
                // Arrange
                var mockRepo = new Mock<ICorrespondentRepository>();
                var mockMapper = new Mock<IMapper>();

                mockRepo.Setup(repo => repo.UpdateCorrespondent(It.IsAny<DataAccess.Entities.Correspondent>()));
                mockMapper.Setup(mapper => mapper.Map<DataAccess.Entities.Correspondent>(It.IsAny<Correspondent>()))
                    .Returns(new DataAccess.Entities.Correspondent());

                var CL = new CorrespondentLogic(mockRepo.Object, mockMapper.Object);
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
                CL.UpdateCorrespondent(validCorrespondent);

                // Assert
                mockRepo.Verify(repo => repo.UpdateCorrespondent(It.IsAny<DataAccess.Entities.Correspondent>()), Times.Once);
            }

        
            [Fact]
            public void DeleteCorrespondent_WithInvalidId_ReturnsTrue()
            {
                // Arrange
                var mockRepo = new Mock<ICorrespondentRepository>();
                var mockMapper = new Mock<IMapper>();

                var CL = new CorrespondentLogic(mockRepo.Object, mockMapper.Object);
                var invalidId = -1; // Invalid id

                // Act
                var result = CL.DeleteCorrespondent(invalidId);

                // Assert
                Assert.True(result);
                // Add more assertions if needed
            }

            // Add more test cases as needed to cover different scenarios and edge cases.

        }


    }
}