using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Repository.Interfaces;
using Umss.BloodOrgansDonationApp.Services.Interfaces;

namespace Umss.BloodOrgansDonationApp.Services
{
    public class DonationCenterService : IDonationCenterService
    {
        private readonly IDonationCenterRepository _donationCenterRepository;
        public DonationCenterService(IDonationCenterRepository donationCenterRepository)
        {
            _donationCenterRepository = donationCenterRepository;
        }
        public async Task<DonationCenter> Create(DonationCenterRequest donationCenterRequest)
        {
            var donationCenter = new DonationCenter
            {
                Id = Guid.NewGuid(),
                Image = donationCenterRequest.Image,
                Name = donationCenterRequest.Name,
                Address = donationCenterRequest.Address,
                DonationTypes = donationCenterRequest.DonationTypes,
                City = donationCenterRequest.City,
            };

            await _donationCenterRepository.Create(donationCenter);

            return donationCenter;
        }

        public async Task Delete(Guid id)
        {
            var donationCenter = await _donationCenterRepository.Get(id);
            if (donationCenter != null)
            {
                await _donationCenterRepository.Delete(id);
            }
            else
            {
                throw new Exception("");
            }
        }

        public async Task<DonationCenter> Get(Guid id)
        {
            var donationCenter = await _donationCenterRepository.Get(id);
            if (donationCenter != null)
            {
                return donationCenter;
            }
            else
            {
                throw new Exception("");
            }
        }

        public async Task<IEnumerable<DonationCenter>> GetAll()
        {
            return await _donationCenterRepository.GetAll();
        }

        public async Task<DonationCenter> Update(Guid id, DonationCenterRequest donationCenterRequest)
        {
            var donationCenter = await _donationCenterRepository.Get(id);
            if (donationCenter != null)
            {
                donationCenter.Name = donationCenterRequest.Name;
                donationCenter.Image = donationCenterRequest.Image;
                donationCenter.DonationTypes = donationCenterRequest.DonationTypes;
                donationCenter.Address = donationCenterRequest.Address;

                await _donationCenterRepository.Update(donationCenter);
                return donationCenter;
            }
            else
            {
                throw new Exception("");
            }
        }
    }
}
