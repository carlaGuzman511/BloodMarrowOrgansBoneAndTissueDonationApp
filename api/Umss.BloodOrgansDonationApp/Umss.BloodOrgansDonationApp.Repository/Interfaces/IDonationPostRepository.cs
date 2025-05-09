namespace Umss.BloodOrgansDonationApp.Repository.Interfaces
{
    public interface IDonationPostRepository<DonationPost>
    {
        public Task<IEnumerable<DonationPost>> GetByDonationCenter(Guid donationCenterId);
        public Task<DonationPost?> GetByDonationCenter(Guid donationCenterId, Guid DonationPostId);
        public Task<IEnumerable<DonationPost>> GetByUser(Guid userId);
        public Task<DonationPost?> GetByUser(Guid userId, Guid DonationPostId);
        public Task DeleteByDonationCenter(Guid donationCenterId, Guid DonationPostId);
        public Task DeleteByUser(Guid userId, Guid DonationPostId);
        public Task<DonationPost> Create(DonationPost donationPost);
        public Task<DonationPost> Update(DonationPost donationPost);
    }
}
