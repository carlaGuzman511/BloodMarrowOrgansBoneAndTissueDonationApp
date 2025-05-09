using Microsoft.EntityFrameworkCore;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Repository.Interfaces;

namespace Umss.BloodOrgansDonationApp.Repository
{
    public class BloodTypeRepository : IBloodTypeRepository
    {
        private readonly DonationAppContext _donationAppContext;
        public BloodTypeRepository(DonationAppContext donationAppContext)
        {
            _donationAppContext = donationAppContext;
        }
        public async Task<BloodType> Create(BloodType element)
        {
            await _donationAppContext.AddAsync(element);
            await _donationAppContext.SaveChangesAsync();

            return element;
        }

        //TODO: Implement a soft delete due foreign key issues.
        public async Task Delete(Guid id)
        {
            BloodType? bloodType = await Get(id);
            if (bloodType != null)
            {
                _donationAppContext.Remove(bloodType);
                await _donationAppContext.SaveChangesAsync();
            }
        }

        public async Task<BloodType?> Get(Guid id)
        {
            return await _donationAppContext.BloodTypes.FindAsync(id);
        }

        public async Task<IEnumerable<BloodType>> GetAll()
        {
            return await _donationAppContext.BloodTypes.ToListAsync();
        }
        public async Task<BloodType> Update(BloodType element)
        {
            await _donationAppContext.SaveChangesAsync();
            return element;
        }
    }
}
