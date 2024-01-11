using BusinessLogic.Entities;
using BusinessLogic.Validators;
using DataAccess.Entities;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BusinessLogic.Tests
{
    public class UserValidatorTests
    {
        [Fact]
        public void Should_Have_Error_When_Username_Is_Empty()
        {
            // Arrange
            var user = new Entities.User { Username = "", Password = "password123" };
            var validator = new UserValidator();

            // Act
            var result = validator.TestValidate(user);

            // Assert
            result.ShouldHaveValidationErrorFor(u => u.Username)
                  .WithErrorMessage("Username is required");
        }

        [Fact]
        public void Should_Have_Error_When_Password_Is_Empty()
        {
            // Arrange
            var user = new Entities.User { Username = "john_doe", Password = "" };
            var validator = new UserValidator();

            // Act
            var result = validator.TestValidate(user);

            // Assert
            result.ShouldHaveValidationErrorFor(u => u.Password)
                  .WithErrorMessage("Password is required");
        }

        [Fact]
        public void Should_Not_Have_Error_When_Username_And_Password_Are_Present()
        {
            // Arrange
            var user = new Entities.User { Username = "john_doe", Password = "password123" };
            var validator = new UserValidator();

            // Act
            var result = validator.TestValidate(user);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
