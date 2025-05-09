using AutoMapper;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Exceptions;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Repository.Interfaces;
using Umss.BloodOrgansDonationApp.Services.Interfaces;
using Umss.BloodOrgansDonationApp.Services.Validators;

namespace Umss.BloodOrgansDonationApp.Services
{
    public class DonationPostService : IDonationPostService
    {
        private readonly IDonationPostRepository _donationPostRepository;
        private readonly IMapper _mapper;
        public DonationPostService(IDonationPostRepository donationPostRepository, IMapper mapper)
        {
            _donationPostRepository = donationPostRepository;
            _mapper = mapper;
        }
        public async Task<DonationPost> Create(DonationPostRequest donationPostRequest)
        {
            DonationPostRequestValidator donationPostRequestValidator = new DonationPostRequestValidator();
            donationPostRequestValidator.Validate(donationPostRequest);

            DonationPost donationPost = _mapper.Map<DonationPost>(donationPostRequest);
            donationPost.Id = Guid.NewGuid();

            return await _donationPostRepository.Create(donationPost);
        }

        public async Task Delete(Guid id)
        {
            await _donationPostRepository.Delete(id);
        }

        public async Task<DonationPost?> Get(Guid id)
        {
            DonationPost? donationPost = await _donationPostRepository.Get(id);
            if (donationPost != null)
            {
                return donationPost;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<DonationPost>> GetAll()
        {
            var donationPosts = await _donationPostRepository.GetAll();

            return donationPosts;
        }

        public async Task<DonationPost> Update(Guid id, DonationPostRequest donationPostRequest)
        {
            DonationPost? donationPost = await _donationPostRepository.Get(id);
            if(donationPost == null)
            {
                throw new EntityNotFoundException($"Donation Post with ID {id} not found.");
            }

            DonationPostRequestValidator donationPostRequestValidator = new DonationPostRequestValidator();
            donationPostRequestValidator.Validate(donationPostRequest);

            _mapper.Map(donationPostRequest, donationPost);
            donationPost.Id = id;
               
            return await _donationPostRepository.Update(donationPost);
        }
    }
}
