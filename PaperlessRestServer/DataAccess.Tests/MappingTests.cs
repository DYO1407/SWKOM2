using Xunit;
using AutoMapper;
using BusinessLogic.Entities;
using BusinessLogic.DataAccessMappingProfile;

namespace DataAccess.Tests
{
    public class MappingTests
    {

        public class AutoMapperMappingTests
        {
            private readonly IMapper _mapper;

            public AutoMapperMappingTests()
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<DataAccessMappingProfile>();
                });
                _mapper = config.CreateMapper();
            }

            [Fact]
            public void Should_Map_Correspondent_From_DAL_To_BL_Correctly()
            {
            

                // Arrange
                var dalCorrespondent = new DataAccess.Entities.Correspondent
                {
                    Id = 1,
                    Name = "Dude"
                };

                // Act
                var blCorrespondent = _mapper.Map<BusinessLogic.Entities.Correspondent>(dalCorrespondent);

                // Assert
                Assert.NotNull(blCorrespondent);
                Assert.Equal(dalCorrespondent.Name, blCorrespondent.Name); 
            }

            [Fact]
            public void Should_Map_Correspondent_From_BL_To_DAL_Correctly()
            {
                // Arrange
                var blCorrespondent = new BusinessLogic.Entities.Correspondent
                {
                    Id = 1,
                    Name = "Dude"
                };

                // Act
                var dalCorrespondent = _mapper.Map<DataAccess.Entities.Correspondent>(blCorrespondent);

                // Assert
                Assert.NotNull(dalCorrespondent);
                Assert.Equal(dalCorrespondent.Name, blCorrespondent.Name);
            }

            [Fact]
            public void Should_Map_Document_From_DAL_To_BL_Correctly()
            {


                // Arrange
                var dalDocument = new DataAccess.Entities.Document
                {
                    Id = 7,
                    
                };

                // Act
                var blDocument = _mapper.Map<BusinessLogic.Entities.Document>(dalDocument);

                // Assert
                Assert.NotNull(blDocument);
                Assert.Equal(dalDocument.Id, blDocument.Id);
            }

        }

    }

    }
