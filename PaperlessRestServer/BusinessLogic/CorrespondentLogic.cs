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
        private readonly CorrespondentsValidator _validator = new CorrespondentsValidator();
        

        public CorrespondentLogic(ICorrespondentRepository correspondentRepository, IMapper mapper)
        {
            _correspondentRepository = correspondentRepository;
            _mapper = mapper;
        }

     





        public Correspondent CreateCorrespondent(Correspondent newcorrespondent)
        {
            ValidateCorrespondent(newcorrespondent);
            _correspondentRepository.AddCorrespondent(_mapper.Map<DataAccess.Entities.Correspondent>(newcorrespondent));

            return newcorrespondent;
        }

        public bool DeleteCorrespondent(int id)
        {
            _correspondentRepository.DeleteCorrespondent(id);
            return true;
        }

        public Correspondent GetCorrespondent(int id)
        {
            _correspondentRepository.GetCorrespondent(id);

            return new Correspondent { Id = id };   
        }

        public Correspondent UpdateCorrespondent(Correspondent correspondent)
        {
            ValidateCorrespondent(correspondent);
            _correspondentRepository.UpdateCorrespondent(_mapper.Map<DataAccess.Entities.Correspondent>(correspondent));
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