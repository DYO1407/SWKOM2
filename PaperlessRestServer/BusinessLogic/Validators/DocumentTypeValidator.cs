using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;
using FluentValidation;

namespace BusinessLogic.Validators
{
    public class DocumentTypeValidator : AbstractValidator<DocumentType>
    {
        public DocumentTypeValidator()
        
        {

            RuleFor(dt => dt.Id).NotEmpty();
            RuleFor(dt => dt.Slug).NotNull().NotEmpty();
            RuleFor(dt => dt.Name).NotNull().NotEmpty();
            RuleFor(dt => dt.Match).NotNull().NotEmpty();
            RuleFor(dt => dt.Match).NotNull().NotEmpty();
            RuleFor(dt => dt.MatchingAlgorithm).NotEmpty();
            RuleFor(dt => dt.IsInsensitive).NotNull();
            RuleFor(dt => dt.DocumentCount).NotEmpty();

        }
    }
}
