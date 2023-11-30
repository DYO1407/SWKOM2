using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;
using FluentValidation;


namespace BusinessLogic.Validators
{
	public class CorrespondentsValidator : AbstractValidator<Correspondent>
	{
		public CorrespondentsValidator()
		{

            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Slug).NotNull().NotEmpty();
            RuleFor(c => c.Name).NotNull().NotEmpty().WithMessage("Name is Required");
            RuleFor(c => c.Match).NotNull().NotEmpty();
            RuleFor(c => c.Matching_Algorithm).NotEmpty();
            RuleFor(c => c.IsInsensitive).NotEmpty();
            RuleFor(c => c.DocumentCount).NotEmpty();
            RuleFor(c => c.LastCorrespondence).NotEmpty();


        }
	}

}
