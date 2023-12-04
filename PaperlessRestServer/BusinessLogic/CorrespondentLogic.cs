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
        public Correspondent CreateCorrespondent(Correspondent newBLCorrespondent)
        {
            ValidateCorrespondent(newBLCorrespondent);
            var newDALCorrespondent = _mapper.Map<DataAccess.Entities.Correspondent>(newBLCorrespondent);
            _correspondentRepository.AddCorrespondent(newDALCorrespondent);

            return newBLCorrespondent;
        }

        public bool DeleteCorrespondent(int id)
        {
            _correspondentRepository.DeleteCorrespondent(id);
            return true;
        }

        public Correspondent GetCorrespondent(int page)
        {
            var correspondent = _mapper.Map<BusinessLogic.Entities.Correspondent>(_correspondentRepository.GetCorrespondent(page));
            return correspondent;   
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