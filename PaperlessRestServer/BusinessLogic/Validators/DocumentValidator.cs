using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;
using FluentValidation;

namespace BusinessLogic.Validators
{
    public class DocumentValidator : AbstractValidator<Document>
    {
        public DocumentValidator()
        {

            RuleFor(d => d.Id).NotEmpty();
            RuleFor(d => d.Correspondent).NotEmpty();
            RuleFor(d => d.DocumentType).NotEmpty();
            //RuleFor(d => d.StoragePath).NotEmpty();
            RuleFor(d => d.Title).NotNull().NotEmpty();
            RuleFor(d => d.Content).NotNull().NotEmpty();
            RuleFor(d => d.Tags).NotEmpty();
            /*RuleFor(d => d.Created).NotEmpty();
            RuleFor(d => d.CreatedDate).NotEmpty();
            RuleFor(c => c.Modified).NotEmpty();
            RuleFor(c => c.Added).NotEmpty();
            RuleFor(d => d.ArchiveSerialNumber).NotEmpty();
            RuleFor(d => d.OriginalFileName).NotEmpty();
            RuleFor(d => d.ArchivedFileName).NotEmpty();*/

        }
    }
}
