using Microsoft.EntityFrameworkCore;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Repository.Interfaces;

namespace Umss.BloodOrgansDonationApp.Repository
{
    public class DonationTypeRepository : IDonationTypeRepository
    {
        private readonly DonationAppContext _appContext;

        public DonationTypeRepository(DonationAppContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<DonationType> Create(DonationType element)
        {
            await _appContext.AddAsync(element);
            await _appContext.SaveChangesAsync();
            return element;
        }

        //TODO: Implement a soft delete due foreign key issues.
        public async Task Delete(Guid id)
        {
            DonationType? donationType = await Get(id);
            if (donationType != null)
            {
                _appContext.Remove(donationType);
                await _appContext.SaveChangesAsync();
            }
        }

        public async Task<DonationType?> Get(Guid id)
        {
            return await _appContext.DonationTypes.FindAsync(id);
        }

        public async Task<IEnumerable<DonationType>> GetAll()
        {
            return await _appContext.DonationTypes.ToListAsync();
        }

        public async Task<IEnumerable<DonationType>> GetByIds(IEnumerable<Guid> donationTypeIds)
        {
            return await _appContext.DonationTypes.Where(x => donationTypeIds.Contains(x.Id)).ToListAsync();
        }

        public async Task<DonationType> Update(DonationType element)
        {
            await _appContext.SaveChangesAsync();
            return element;
        }
    }
}
