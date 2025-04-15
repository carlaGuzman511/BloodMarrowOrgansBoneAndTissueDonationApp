using System.Diagnostics;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Repository.Interfaces;
using Umss.BloodOrgansDonationApp.Services.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace Umss.BloodOrgansDonationApp.Services
{
    public class DonationTypeService : IDonationTypeService
    {
        private readonly IDonationTypeRepository _donationTypeRepository;
        public DonationTypeService(IDonationTypeRepository donationTypeRepository)
        {
            _donationTypeRepository = donationTypeRepository;
        }
        public async Task<DonationType> Create(DonationTypeRequest donationTypeRequest)
        {
            var donationType = new DonationType
            {
                Id = Guid.NewGuid(),
                Name = donationTypeRequest.Name,
                Description = donationTypeRequest.Description,
                Requirements = donationTypeRequest.Requirements,
                Process = donationTypeRequest.Process,
                Importance = donationTypeRequest.Importance,
                Benefits = donationTypeRequest.Benefits,
                SecondaryEffects = donationTypeRequest.SecondaryEffects,
                Image = donationTypeRequest.Image,
            };

            return donationType;
        }

        public async Task Delete(Guid id)
        {
            var donationType = await _donationTypeRepository.Get(id);
            if (donationType != null)
            {
                await _donationTypeRepository.Delete(id);
            }
            else
            {
                throw new Exception("");
            } 
        }

        public async Task<DonationType> Get(Guid id)
        {
            var donationType = await _donationTypeRepository.Get(id);
            if (donationType != null) 
            { 
                return donationType;
            }
            else
            {
                throw new Exception("");
            }
        }

        public async Task<IEnumerable<DonationType>> GetAll()
        {
            return await _donationTypeRepository.GetAll();
        }

        public async Task<DonationType> Update(Guid id, DonationTypeRequest donationTypeRequest)
        {
            var donationType = await _donationTypeRepository.Get(id);
            if (donationType != null) 
            {
                donationType.Name = donationTypeRequest.Name;
                donationType.Description = donationTypeRequest.Description;
                donationType.Requirements = donationTypeRequest.Requirements;
                donationType.Process = donationTypeRequest.Process;
                donationType.Importance = donationTypeRequest.Importance;
                donationType.Benefits = donationTypeRequest.Benefits;
                donationType.SecondaryEffects = donationTypeRequest.SecondaryEffects;
                donationType.Image = donationTypeRequest.Image;

                await _donationTypeRepository.Update(donationType);
                
                return donationType;
            }
            else
            {
                throw new Exception("");
            }
        }
    }
}
