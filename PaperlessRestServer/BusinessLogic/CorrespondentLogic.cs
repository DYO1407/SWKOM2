using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using BusinessLogic.Validators;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using ValidationException = FluentValidation.ValidationException;
using DataAccess.Interfaces;
using AutoMapper;

namespace BusinessLogic
{
    public class CorrespondentLogic : ICorrespondentLogic
    {
        private readonly ICorrespondentRepository _correspondentRepository;
        private readonly IMapper _mapper;

        public CorrespondentLogic(ICorrespondentRepository correspondentRepository, IMapper mapper)
        {
            _correspondentRepository = correspondentRepository;
            _mapper = mapper;
        }

        public CorrespondentLogic()
        {
            
        }



        private readonly CorrespondentsValidator _validator = new CorrespondentsValidator();



        public Correspondent CreateCorrespondent(Correspondent newcorrespondent)
        {
            ValidateCorrespondent(newcorrespondent);

            return newcorrespondent;
        }

        public bool DeleteCorrespondent(int id)
        {
            return true;
        }

        public Correspondent GetCorrespondent(int id)
        {
            return new Correspondent { Id = id };   
        }

        public Correspondent UpdateCorrespondent(Correspondent correspondent)
        {
            ValidateCorrespondent(correspondent);
            return correspondent;
        }

        private void ValidateCorrespondent(Correspondent correspondent)
        {
            var validationResult = _validator.Validate(correspondent);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}