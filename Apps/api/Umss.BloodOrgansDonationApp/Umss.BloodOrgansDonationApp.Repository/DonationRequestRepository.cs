using Microsoft.EntityFrameworkCore;
using Umss.BloodOrgansDonationApp.Repository.Interfaces;
using Umss.BloodOrgansDonationApp.Models;

namespace Umss.BloodOrgansDonationApp.Repository
{
    public class DonationPostRepository : IDonationPostRepository
    {
        private readonly DonationAppContext _appContext;

        public DonationPostRepository(DonationAppContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<DonationPost> Create(DonationPost element)
        {
            await _appContext.AddAsync(element);
            await _appContext.SaveChangesAsync();
            return element;
        }

        public async Task Delete(Guid id)
        {
            DonationPost donationPost = await Get(id);
            if (donationPost != null)
            {
                _appContext.Remove(donationPost);
                await _appContext.SaveChangesAsync();
            }
        }

        public async Task<DonationPost> Get(Guid id)
        {
            return await _appContext.DonationPosts.FindAsync(id);
        }

        public async Task<IEnumerable<DonationPost>> GetAll()
        {
            return await _appContext.DonationPosts.ToListAsync();
        }

        public async Task<DonationPost> Update(DonationPost element)
        {
            _appContext.Update(element);
            await _appContext.SaveChangesAsync();
            return element;
        }
    }
}
