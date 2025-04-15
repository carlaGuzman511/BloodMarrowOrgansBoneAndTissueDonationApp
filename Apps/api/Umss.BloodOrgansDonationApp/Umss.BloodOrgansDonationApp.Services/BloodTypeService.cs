using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Repository.Interfaces;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Services.Interfaces;

namespace Umss.BloodOrgansDonationApp.Services
{
    public class BloodTypeService : IBloodTypeService
    {
        private readonly IBloodTypeRepository _bloodTypeRepository;
        public BloodTypeService(IBloodTypeRepository bloodTypeRepository)
        {
            this._bloodTypeRepository = bloodTypeRepository;
        }
        public async Task<BloodType> Create(BloodTypeRequest bloodTypeRequest)
        {
            var bloodType = new BloodType
            {
                Image = bloodTypeRequest.Image,
                Name = bloodTypeRequest.Name,
                Id = Guid.NewGuid()
            };

            return await _bloodTypeRepository.Create(bloodType);
        }

        public async Task Delete(Guid id)
        {
            var bloodType = await _bloodTypeRepository.Get(id);
            if (bloodType != null) 
            { 
                await _bloodTypeRepository.Delete(id);
            }
            else
            {
                throw new ArgumentNullException("");
            }
        }

        public async Task<BloodType> Get(Guid id)
        {
            var bloodType = await _bloodTypeRepository.Get(id);
            if (bloodType != null) 
            {
                return bloodType;
            }
            else
            {
                throw new ArgumentNullException("");
            }
        }

        public async Task<IEnumerable<BloodType>> GetAll()
        {
            return await _bloodTypeRepository.GetAll();
        }

        public async Task<BloodType> Update(Guid id, BloodTypeRequest bloodTypeRequest)
        {
            var bloodType = await _bloodTypeRepository.Get(id);
            if (bloodType != null) 
            {
                bloodType.Name = bloodTypeRequest.Name;
                bloodType.Image = bloodTypeRequest.Image;

                await _bloodTypeRepository.Update(bloodType);

                var response = await Get(bloodType.Id);
                return response;
            }
            else
            {
                throw new ArgumentNullException("");
            }
        }
    }
}
