using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using BusinessLogic.Validators;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using ValidationException = FluentValidation.ValidationException;
using DataAccess.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class CorrespondentLogic : ICorrespondentLogic
    {
        private readonly ICorrespondentRepository _correspondentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CorrespondentLogic> _logger;
        private readonly CorrespondentsValidator _validator = new CorrespondentsValidator();
        

        public CorrespondentLogic(ICorrespondentRepository correspondentRepository, IMapper mapper, ILogger<CorrespondentLogic> logger)
        {
            _correspondentRepository = correspondentRepository;
            _mapper = mapper;
            _logger = logger;
            _logger.LogInformation("CorrespondetLogic Initialized");
        }
        public Correspondent CreateCorrespondent(Correspondent newBLCorrespondent)
        {
            ValidateCorrespondent(newBLCorrespondent);
            var newDALCorrespondent = _mapper.Map<DataAccess.Entities.Correspondent>(newBLCorrespondent);
            try
            {
                _correspondentRepository.AddCorrespondent(newDALCorrespondent);
                _logger.LogInformation($"New Correspondent { JsonSerializer.Serialize(newDALCorrespondent) } created");
            }
            catch(Exception ex)
            {
                _logger.LogError($"Correspondent creation for {JsonSerializer.Serialize(newDALCorrespondent)} failed");
            }
            return newBLCorrespondent;
        }

        public bool DeleteCorrespondent(int id)
        {
            try
            {
                _correspondentRepository.DeleteCorrespondent(id);
                _logger.LogInformation($"Correspondent with ID: {id} successfully deleted");
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Correspondent with ID: {id} could not be deleted");
                return false;
            }
        }

        public Correspondent GetCorrespondent(int page)
        {
            Correspondent correspondent = new Correspondent();
            try
            {
                correspondent = _mapper.Map<BusinessLogic.Entities.Correspondent>(_correspondentRepository.GetCorrespondent(page));
                _logger.LogInformation($"Correspondent { JsonSerializer.Serialize(correspondent) } found");
            }
            catch (Exception ex)
            {
                _logger.LogError($"No Correspondents found for ID: {page} found");
            }
            return correspondent;   
        }

        public Correspondent UpdateCorrespondent(Correspondent correspondent)
        {
            try
            {
                ValidateCorrespondent(correspondent);
                var updatedCorrespondent = _mapper.Map<BusinessLogic.Entities.Correspondent>(_correspondentRepository.UpdateCorrespondent(_mapper.Map<DataAccess.Entities.Correspondent>(correspondent)));
                _logger.LogInformation($"Correspondent { JsonSerializer.Serialize(updatedCorrespondent) } successfully updated");
            }
            catch (ValidationException ex)
            {
                _logger.LogError($"Correspondent validation for { JsonSerializer.Serialize(correspondent) } failed");
            }
            catch(Exception ex)
            {
                _logger.LogError($"Correspondent { JsonSerializer.Serialize(correspondent) } could not be updated");
            }
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