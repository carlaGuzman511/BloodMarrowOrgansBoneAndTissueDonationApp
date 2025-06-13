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
        public async Task<DonationPost> Create(DonationPost donationPost)
        {
            await _appContext.AddAsync(donationPost);
            await _appContext.SaveChangesAsync();
            return donationPost;
        }
        public async Task DeleteByUser(Guid userId, Guid donationPostId) 
        {
            DonationPost? donationPost = await GetByUser(userId, donationPostId);
            if (donationPost != null)
            {
                _appContext.Remove(donationPost);
                await _appContext.SaveChangesAsync();
            }
        }
        public async Task DeleteByDonationCenter(Guid donationCenterId, Guid donationPostId)
        {
            DonationPost? donationPost = await GetByDonationCenter(donationCenterId, donationPostId);
            if (donationPost != null)
            {
                _appContext.Remove(donationPost);
                await _appContext.SaveChangesAsync();
            }
        }
        public async Task<DonationPost?> GetByUser(Guid userId, Guid donationPostId)
        {
            return await _appContext.DonationPosts
                .Where(dp => dp.UserId == userId && dp.Id == donationPostId)
                .Include(dp => dp.BloodType)
                .Include(dp => dp.DonationType)
                .Include(dp => dp.User)
                .Include(dp => dp.DonationCenter)
                .Include(dp => dp.Comments)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<DonationPost>> Get()
        {
            return await _appContext.DonationPosts
                .Include(dp => dp.BloodType)
                .Include(dp => dp.DonationType)
                .Include(dp => dp.User)
                .Include(dp => dp.DonationCenter)
                .Include(dp => dp.Comments)
                .ToListAsync();
        }
        public async Task<DonationPost?> GetByDonationCenter(Guid donationCenterId, Guid donationPostId)
        {
            return await _appContext.DonationPosts
                .Where(dp => dp.DonationCenterId == donationCenterId && dp.Id == donationPostId)
                .Include(dp => dp.BloodType)
                .Include(dp => dp.DonationType)
                .Include(dp => dp.User)
                .Include(dp => dp.DonationCenter)
                .Include(dp => dp.Comments)
                .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<DonationPost>> GetByUser(Guid userId)
        {
            return await _appContext.DonationPosts
                .Where (dp => dp.UserId == userId)
                .Include(dp => dp.BloodType)
                .Include(dp => dp.DonationType)
                .Include(dp => dp.DonationCenter)
                .Include(dp => dp.User)
                .Include(dp => dp.Comments)
                .ToListAsync();
        }
        public async Task<IEnumerable<DonationPost>> GetByDonationCenter(Guid donationCenterId)
        {
            return await _appContext.DonationPosts
                .Where(dp => dp.DonationCenterId == donationCenterId)
                .Include(dp => dp.BloodType)
                .Include(dp => dp.DonationType)
                .Include(dp => dp.DonationCenter)
                .Include(dp => dp.User)
                .Include(dp => dp.Comments)
                .ToListAsync();
        }
        public async Task<DonationPost> Update(DonationPost donationPost)
        {
            await _appContext.SaveChangesAsync();
            return donationPost;
        }
    }
}
