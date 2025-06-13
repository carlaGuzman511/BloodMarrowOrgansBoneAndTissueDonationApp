using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;

namespace Umss.BloodOrgansDonationApp.Services.Interfaces
{
    public interface IDonationPostService
    {
        public Task<IEnumerable<DonationPostResponse>> GetByDonationCenter(Guid donationCenterId);
        public Task<DonationPostResponse?> GetByDonationCenter(Guid donationCenterId, Guid DonationPostId);
        public Task<DonationPostResponse> CreateByDonationCenter(Guid donationCenterId, DonationPostRequest donationPostRequest);
        public Task<DonationPostResponse> UpdateByDonationCenter(Guid donationCenterId, Guid DonationPostId, DonationPostRequest donationPostRequest);
        public Task DeleteByDonationCenter(Guid donationCenterId, Guid DonationPostId);

        public Task<IEnumerable<DonationPostResponse>> GetByUser(Guid userId);
        public Task<DonationPostResponse?> GetByUser(Guid userId, Guid DonationPostId);
        public Task<IEnumerable<DonationPostResponse>> Get();
        public Task<DonationPostResponse> CreateByUser(Guid userId, DonationPostRequest donationPostRequest);
        public Task<DonationPostResponse> UpdateByUser(Guid userId, Guid DonationPostId, DonationPostRequest donationPostRequest);
        public Task DeleteByUser(Guid userId, Guid DonationPostId);
    }
}
