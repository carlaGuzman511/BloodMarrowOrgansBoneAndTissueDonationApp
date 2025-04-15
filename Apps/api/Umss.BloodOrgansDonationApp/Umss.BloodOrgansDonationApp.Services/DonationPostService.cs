using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;
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
        public async Task<DonationPostResponse> Create(DonationPostRequest donationPostRequest)
        {
            var donationPost = new DonationPost
            {
                Id = Guid.NewGuid(),
                Description = donationPostRequest.Description,
                UserId = donationPostRequest.UserId,
                Image = donationPostRequest.Image,
                BloodTypeId = donationPostRequest.BloodTypeId,
                DonationTypeId = donationPostRequest.DonationTypeId,
                CreatedAt = DateTime.Now,
            };

            await _donationPostRepository.Create(donationPost);

            var response = new DonationPostResponse
            {
                Id = donationPost.Id,
                DonationTypeId = donationPost.DonationTypeId,
                BloodTypeId = donationPost.BloodTypeId,
                Description = donationPostRequest.Description,
                Image = donationPostRequest.Image,
                CreatedAt = donationPost.CreatedAt,
                UserId = donationPost.UserId,
            };

            return response;
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

        public async Task<DonationPostResponse> Get(Guid id)
        {
            var donationPost = await _donationPostRepository.Get(id);
            if (donationPost != null)
            {
                var response = new DonationPostResponse
                {
                    Id = donationPost.Id,
                    BloodTypeId = donationPost.BloodTypeId,
                    Description = donationPost.Description,
                    DonationTypeId = donationPost.BloodTypeId,
                    UserId = donationPost.UserId,
                    Image = donationPost.Image,
                    CreatedAt = donationPost.CreatedAt,
                    UpdatedAt = donationPost.UpdatedAt,
                };

                return response;
            }
            else
            {
                throw new Exception("");
            }
        }

        public async Task<IEnumerable<DonationPostResponse>> GetAll()
        {
            var donationPosts = await _donationPostRepository.GetAll();
            var response = donationPosts.Select(x => new DonationPostResponse
            {
                Id = x.Id,
                BloodTypeId = x.BloodTypeId,
                Description = x.Description,
                UserId = x.UserId,
                Image = x.Image,
                CreatedAt = x.CreatedAt,
                DonationTypeId = x.DonationTypeId,
                UpdatedAt = x.UpdatedAt,
            });

            return response;
        }

        public async Task<DonationPostResponse> Update(Guid id, DonationPostRequest donationPostRequest)
        {
            var donationPost = await _donationPostRepository.Get(id);
            if (donationPost != null)
            {
                donationPost.Description = donationPostRequest.Description;
                donationPost.UserId = donationPostRequest.UserId;
                donationPost.Image = donationPostRequest.Image;
                donationPost.BloodTypeId = donationPostRequest.BloodTypeId;
                donationPost.DonationTypeId = donationPostRequest.DonationTypeId;
                donationPost.CreatedAt = donationPostRequest.CreatedAt;
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
