using Microsoft.EntityFrameworkCore;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Repository.Interfaces;

namespace Umss.BloodOrgansDonationApp.Repository
{
    public class DonationCenterRepository : IDonationCenterRepository
    {
        private readonly DonationAppContext _appContext;

        public DonationCenterRepository(DonationAppContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<DonationCenter> Create(DonationCenter element)
        {
            await _appContext.AddAsync(element);
            await _appContext.SaveChangesAsync();
            return element;
        }

        public async Task Delete(Guid id)
        {
            DonationCenter? donationCenter = await Get(id);
            if (donationCenter != null)
            {
                _appContext.Remove(donationCenter);
            }
            await _appContext.SaveChangesAsync();
        }

        public async Task<DonationCenter?> Get(Guid id)
        {
            return await _appContext.DonationCenters
                .Include(dc => dc.DonationCenterDonationTypes)
                    .ThenInclude(dcdt => dcdt.DonationType)
                //.Include(dc => dc.DonationPosts)
                .FirstOrDefaultAsync(dc => dc.Id == id);
        }

        public async Task<IEnumerable<DonationCenter>> GetAll()
        {
            return await _appContext.DonationCenters
                .Include(dc => dc.DonationCenterDonationTypes)
                    .ThenInclude(dcdt => dcdt.DonationType)
                //.Include(dc => dc.DonationPosts)
                .ToListAsync();
        }

        public async Task<DonationCenter> Update(DonationCenter element)
        {
            await _appContext.SaveChangesAsync();
            return element;
        }
    }
}
