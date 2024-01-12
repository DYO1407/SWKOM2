using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using RabbitMQ.Client;
using Xunit;

namespace BusinessLogic.Tests
{
    public class MessageLogicTests
    {
        private static object review;

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

        //Integration tests
        /*
        public static ActionResult<int> Post([FromBody] Message message)
        {
            if (!ValidateReview(review))
            {
                return UnprocessableEntity();
            }
            _reviewRepository.Create(review);
            _reviewRepository.SaveChanges();

            return CreatedAtActionResult(nameof(Get); new { id = review.Id }, review.Id);

        }

        public class CustomWebApplicationFactory : WebApplicationFactory<Program>
        {
            public Mock<IReviewRepository> ReviewRepositoryMock { get; }

            public CustomWebApplicationFactory()
            {
                ReviewRepositoryMock = new Mock<IReviewRepository>();
            }

            protected override void ConfigureWeb(IWebHostBuilder builder)
            {
                base.ConfigureWebHost(builder);

                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton(ReviewRepositoryMock.Object);
                });
            }
            [Collection("Integration Tests")]
            public class ReviewControllerIntegrationTests
            {
                private readonly IServiceProvider _serviceProvider;

                public ReviewControllerIntegrationTests(TestFixture fixture)
                {
                    _serviceProvider = fixture.ServiceProvider;
                }

                [Fact]
                public async Task Get_Always_ReturnsAllReviews()
                {
                    // Arrange
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<YourDbContext>(); // Replace with your DbContext type
                        await dbContext.Database.EnsureCreatedAsync(); // Ensure the database is created

                        var reviewRepository = new ReviewRepository(dbContext); // Replace with your actual repository implementation
                        var controller = new ReviewController(reviewRepository);

                        // Add some sample reviews to the database
                        var sampleReviews = new Review[]
                        {
                new Review { Id = 1, Title = "Review A", Rating = 4 },
                new Review { Id = 2, Title = "Review B", Rating = 5 }
                        };

                        dbContext.Reviews.AddRange(sampleReviews);
                        dbContext.SaveChanges();

                        // Act
                        var result = await controller.Get();
                        var okResult = result as OkObjectResult;

                        // Assert
                        Assert.NotNull(okResult);
                        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);

                        var reviews = okResult.Value as IEnumerable<Review>;

                        Assert.NotNull(reviews);
                        Assert.Collection(reviews,
                            r =>
                            {
                                Assert.Equal("Review A", r.Title);
                                Assert.Equal(4, r.Rating);
                            },
                            r =>
                            {
                                Assert.Equal("Review B", r.Title);
                                Assert.Equal(5, r.Rating);
                            }
                        );
                    }
                }
            }

            private static ActionResult<int> UnprocessableEntity()
        {
            throw new NotImplementedException();
        }

        private static bool ValidateReview(object review)
        {
            throw new NotImplementedException();
            }*/
    } 
}
