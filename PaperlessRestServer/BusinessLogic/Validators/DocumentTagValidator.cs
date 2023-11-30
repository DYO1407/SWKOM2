using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;
using FluentValidation;

namespace BusinessLogic.Validators
{
    public class DocumentTagValidator : AbstractValidator<DocumentTag>

    {
        public DocumentTagValidator()
        {

            RuleFor(t => t.Id).NotEmpty();
            RuleFor(t => t.Slug).NotNull().NotEmpty();
            RuleFor(t => t.Name).NotNull().NotEmpty();
            RuleFor(t => t.Match).NotNull().NotEmpty();
            RuleFor(t => t.Color).NotEmpty();
            RuleFor(t => t.Match).NotEmpty();
            RuleFor(t => t.MatchingAlgorithm).NotEmpty();
            RuleFor(t => t.IsInsensitive).NotEmpty();
            RuleFor(t => t.IsInboxTag).NotEmpty();
            RuleFor(t => t.DocumentCount).NotEmpty();
        }
    }
}
