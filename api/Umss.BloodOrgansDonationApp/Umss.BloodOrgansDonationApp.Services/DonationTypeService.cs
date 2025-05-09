using AutoMapper;
using FluentValidation;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Exceptions;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;
using Umss.BloodOrgansDonationApp.Repository;
using Umss.BloodOrgansDonationApp.Repository.Interfaces;
using Umss.BloodOrgansDonationApp.Services.Interfaces;
using Umss.BloodOrgansDonationApp.Services.Validators;

namespace Umss.BloodOrgansDonationApp.Services
{
    public class DonationTypeService : IDonationTypeService
    {
        private readonly IDonationTypeRepository _donationTypeRepository;
        private readonly IMapper _mapper;
        public DonationTypeService(IDonationTypeRepository donationTypeRepository, IMapper mapper)
        {
            _donationTypeRepository = donationTypeRepository;
            _mapper = mapper;
        }
        public async Task<DonationTypeResponse> Create(DonationTypeRequest donationTypeRequest)
        {
            DonationTypeRequestValidator donationTypeRequestValidator = new DonationTypeRequestValidator();
            donationTypeRequestValidator.ValidateAndThrow(donationTypeRequest);

            DonationType donationType = _mapper.Map<DonationType>(donationTypeRequest);
            donationType.Id = Guid.NewGuid();
            
            donationType = await _donationTypeRepository.Create(donationType);

            return _mapper.Map<DonationTypeResponse>(donationType);
        }

        public async Task Delete(Guid id)
        {
            await _donationTypeRepository.Delete(id);
        }

        public async Task<DonationTypeResponse?> Get(Guid id)
        {
            DonationType? donationType = await _donationTypeRepository.Get(id);
            if (donationType != null) 
            {
                return _mapper.Map<DonationTypeResponse>(donationType);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<DonationTypeResponse>> GetAll()
        {
            IEnumerable<DonationType> donationTypes = await _donationTypeRepository.GetAll();
            IEnumerable<DonationTypeResponse> responses = donationTypes.Select(x => _mapper.Map<DonationTypeResponse>(x));

            return responses;
        }

        public async Task<DonationTypeResponse> Update(Guid id, DonationTypeRequest donationTypeRequest)
        {
            DonationType? donationType = await _donationTypeRepository.Get(id);
            if (donationType == null)
            {
                throw new EntityNotFoundException($"Donation Type with ID {id} not found.");
            }

            DonationTypeRequestValidator donationTypeRequestValidator = new DonationTypeRequestValidator();
            donationTypeRequestValidator.ValidateAndThrow(donationTypeRequest);

            _mapper.Map(donationTypeRequest, donationType);
            donationType.Id = id;

            donationType = await _donationTypeRepository.Update(donationType);

            return _mapper.Map<DonationTypeResponse>(donationType);
        }
    }
}
