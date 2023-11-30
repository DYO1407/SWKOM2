using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;
using FluentValidation;

namespace BusinessLogic.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {

            RuleFor(u => u.Username).NotEmpty().WithMessage("Username is required");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Password is required");

        }
    }
}
