using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;



namespace DataAccess.Tests.Sql
{
   /* public class CorrespondentRepositoryTests
    {
        private readonly DbContextOptions<AppDbContext> _options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .Options;

        [Fact]
        public void AddCorrespondent_ValidCorrespondent_CallsSaveChanges()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<CorrespondentRepository>>();

            using (var context = new AppDbContext(_options))
            {
                var repository = new CorrespondentRepository(context, loggerMock.Object);
                var correspondent = new Correspondent { /* Populate valid correspondent properties  };

                // Act
                repository.AddCorrespondent(correspondent);

                // Assert
                Assert.Equal(EntityState.Added, context.Entry(correspondent).State);
                Assert.NotEqual(default, correspondent.Id);
                loggerMock.Verify(x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once);
            }
        }

        [Fact]
        public void DeleteCorrespondent_ExistingCorrespondentId_CallsSaveChanges()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<CorrespondentRepository>>();

            using (var context = new AppDbContext(_options))
            {
                var repository = new CorrespondentRepository(context, loggerMock.Object);
                var correspondent = new Correspondent { /* Populate valid correspondent properties  };
                context.Correspondents.Add(correspondent);
                context.SaveChanges();

                // Act
                repository.DeleteCorrespondent(correspondent.Id);

                // Assert
                Assert.Equal(EntityState.Deleted, context.Entry(correspondent).State);
                loggerMock.Verify(x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once);
            }
        }

        [Fact]
        public void GetAllCorrespondents_CorrespondentsExist_ReturnsCorrespondents()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<CorrespondentRepository>>();

            using (var context = new AppDbContext(_options))
            {
                var repository = new CorrespondentRepository(context, loggerMock.Object);
                var correspondents = new List<Correspondent>
                {
                    new Correspondent { /* Populate valid correspondent properties  },
                    new Correspondent { /* Populate valid correspondent properties  }
                };
                context.Correspondents.AddRange(correspondents);
                context.SaveChanges();

                // Act
                var result = repository.GetAllCorrespondents();

                // Assert
                Assert.NotNull(result);
                Assert.Equal(correspondents.Count, result.Count());
                loggerMock.Verify(x => x.Log(
                    LogLevel.LogError,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Never);
            }
        }

        [Fact]
        public void GetCorrespondent_ExistingCorrespondentId_ReturnsCorrespondent()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<CorrespondentRepository>>();

            using (var context = new AppDbContext(_options))
            {
                var repository = new CorrespondentRepository(context, loggerMock.Object);
                var correspondent = new Correspondent { /* Populate valid correspondent properties};
                context.Correspondents.Add(correspondent);
                context.SaveChanges();

                // Act
                var result = repository.GetCorrespondent(correspondent.Id);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(correspondent.Id, result.Id);
                loggerMock.Verify(x => x.Log(
                    LogLevel.LogError,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Never);
            }
        }

        [Fact]
        public void GetCorrespondent_NonExistingCorrespondentId_ThrowsCorrespondentNotFoundException()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<CorrespondentRepository>>();

            using (var context = new AppDbContext(_options))
            {
                var repository = new CorrespondentRepository(context, loggerMock.Object);

                // Act & Assert
                Assert.Throws<CorrespondentNotFoundException>(() => repository.GetCorrespondent(999));
                loggerMock.Verify(x => x.Log(
                    LogLevel.LogWarning,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once);
            }
        }

        [Fact]
        public void UpdateCorrespondent_ExistingCorrespondent_CallsSaveChanges()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<CorrespondentRepository>>();

            using (var context = new AppDbContext(_options))
            {
                var repository = new CorrespondentRepository(context, loggerMock.Object);
                var correspondent = new Correspondent { /* Populate valid correspondent properties };
                context.Correspondents.Add(correspondent);
                context.SaveChanges();

                var updatedCorrespondent = new Correspondent
                {
                    Id = correspondent.Id,
                    /* Populate updated correspondent properties
                };

                // Act
                var result = repository.UpdateCorrespondent(updatedCorrespondent);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(EntityState.Modified, context.Entry(updatedCorrespondent).State);
                loggerMock.Verify(x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once);
            }
        }
    }*/
}
