using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Repository.Interfaces;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Services.Interfaces;
using Umss.BloodOrgansDonationApp.Services.Validators;
using FluentValidation;
using AutoMapper;
using Umss.BloodOrgansDonationApp.Models.Exceptions;

namespace Umss.BloodOrgansDonationApp.Services
{
    public class BloodTypeService : IBloodTypeService
    {
        private readonly IBloodTypeRepository _bloodTypeRepository;
        private readonly IMapper _mapper;
        public BloodTypeService(IBloodTypeRepository bloodTypeRepository, IMapper mapper)
        {
            _bloodTypeRepository = bloodTypeRepository;
            _mapper = mapper;
        }
        public async Task<BloodType> Create(BloodTypeRequest bloodTypeRequest)
        {
            BloodTypeRequestValidator bloodTypeRequestValidator = new BloodTypeRequestValidator();
            bloodTypeRequestValidator.ValidateAndThrow(bloodTypeRequest);

            var bloodType = _mapper.Map<BloodType>(bloodTypeRequest);
            bloodType.Id = Guid.NewGuid();

            return await _bloodTypeRepository.Create(bloodType);
        }

        public async Task Delete(Guid id)
        {
            await _bloodTypeRepository.Delete(id);
        }

        public async Task<BloodType?> Get(Guid id)
        {
            return await _bloodTypeRepository.Get(id);
        }

        public async Task<IEnumerable<BloodType>> GetAll()
        {
            return await _bloodTypeRepository.GetAll();
        }

        public async Task<BloodType> Update(Guid id, BloodTypeRequest bloodTypeRequest)
        {
            BloodType? bloodType = await _bloodTypeRepository.Get(id);
            if (bloodType == null)
            {
                throw new EntityNotFoundException($"BloodType with ID {id} not found.");
            }

            BloodTypeRequestValidator bloodTypeRequestValidator = new BloodTypeRequestValidator();
            bloodTypeRequestValidator.ValidateAndThrow(bloodTypeRequest);

            _mapper.Map(bloodTypeRequest, bloodType);
            bloodType.Id = id;

            return await _bloodTypeRepository.Update(bloodType);
        }
    }
}
