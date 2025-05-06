using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Repository.Interfaces;
using Umss.BloodOrgansDonationApp.Services.Interfaces;

namespace Umss.BloodOrgansDonationApp.Services
{
    public class DonationPostService : IDonationPostService
    {
        private readonly IDonationPostRepository _donationPostRepository;
        public DonationPostService(IDonationPostRepository donationPostRepository)
        {
            _donationPostRepository = donationPostRepository;
        }
        public async Task<DonationPost> Create(DonationPostRequest donationPostRequest)
        {
            var donationPost = new DonationPost
            {
                Id = Guid.NewGuid(),
                Description = donationPostRequest.Description,
                UserId = donationPostRequest.UserId,
                DonationCenterId = donationPostRequest.DonationCenterId,
                Image = donationPostRequest.Image,
                BloodTypeId = donationPostRequest.BloodTypeId,
                DonationTypeId = donationPostRequest.DonationTypeId,
                CreatedAt = DateTime.Now,
            };

            await _donationPostRepository.Create(donationPost);
            return donationPost;
        }

        public async Task Delete(Guid id)
        {
            var donationPost = await _donationPostRepository.Get(id);
            if (donationPost != null)
            {
                await _donationPostRepository.Delete(id);
            }
            else
            {
                throw new Exception("");
            }
        }

        public async Task<DonationPost> Get(Guid id)
        {
            var donationPost = await _donationPostRepository.Get(id);
            if (donationPost != null)
            {
                return donationPost;
            }
            else
            {
                throw new Exception("");
            }
        }

        public async Task<IEnumerable<DonationPost>> GetAll()
        {
            var donationPosts = await _donationPostRepository.GetAll();

            return donationPosts;
        }

        public async Task<DonationPost> Update(Guid id, DonationPostRequest donationPostRequest)
        {
            var donationPost = await _donationPostRepository.Get(id);
            if (donationPost != null)
            {
                donationPost.Description = donationPostRequest.Description;
                donationPost.UserId = donationPostRequest.UserId;
                donationPost.Image = donationPostRequest.Image;
                donationPost.BloodTypeId = donationPostRequest.BloodTypeId;
                donationPost.DonationTypeId = donationPostRequest.DonationTypeId;
                donationPost.DonationCenterId = donationPostRequest.DonationCenterId;
                donationPost.UpdatedAt = DateTime.Now;
                
                await _donationPostRepository.Update(donationPost);

                var response = await Get(donationPost.Id);
                return response;
            }
            else
            {
                throw new Exception("");
            }
        }
    }
}
