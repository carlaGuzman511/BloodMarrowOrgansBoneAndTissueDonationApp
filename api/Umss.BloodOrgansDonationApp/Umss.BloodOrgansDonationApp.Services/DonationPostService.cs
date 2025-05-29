using AutoMapper;
using FluentValidation;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Exceptions;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;
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
        public async Task<DonationPostResponse> CreateByDonationCenter(Guid donationCenterId, DonationPostRequest donationPostRequest)
        {
            DonationPostRequestValidator donationPostRequestValidator = new DonationPostRequestValidator();
            donationPostRequestValidator.ValidateAndThrow(donationPostRequest);

            DonationPost donationPost = _mapper.Map<DonationPost>(donationPostRequest);
            donationPost.CreatedAt = DateTime.Now;
            donationPost.Id = Guid.NewGuid();
            donationPost.DonationCenterId = donationCenterId;

            donationPost = await _donationPostRepository.Create(donationPost);

            return _mapper.Map<DonationPostResponse>(donationPost);
        }
        public async Task<DonationPostResponse> CreateByUser(Guid userId, DonationPostRequest donationPostRequest)
        {
            DonationPostRequestValidator donationPostRequestValidator = new DonationPostRequestValidator();
            donationPostRequestValidator.ValidateAndThrow(donationPostRequest);

            DonationPost donationPost = _mapper.Map<DonationPost>(donationPostRequest);
            donationPost.CreatedAt = DateTime.Now;
            donationPost.Id = Guid.NewGuid();
            donationPost.UserId = userId;

            donationPost = await _donationPostRepository.Create(donationPost);

            return _mapper.Map<DonationPostResponse>(donationPost);
        }
        public async Task DeleteByUser(Guid userId, Guid donationPostId)
        {
            await _donationPostRepository.DeleteByUser(userId, donationPostId);
        }
        public async Task DeleteByDonationCenter(Guid donationCenterId, Guid donationPostId)
        {
            await _donationPostRepository.DeleteByDonationCenter(donationCenterId, donationPostId);
        }
        public async Task<DonationPostResponse?> GetByUser(Guid userId, Guid donationPostId)
        {
            DonationPost? donationPost = await _donationPostRepository.GetByUser(userId, donationPostId);
            if (donationPost != null)
            {
                return _mapper.Map<DonationPostResponse>(donationPost);
            }
            else
            {
                return null;
            }
        }
        public async Task<DonationPostResponse?> GetByDonationCenter(Guid donationCenterId, Guid donationPostId)
        {
            DonationPost? donationPost = await _donationPostRepository.GetByDonationCenter(donationCenterId, donationPostId);
            if (donationPost != null)
            {
                return _mapper.Map<DonationPostResponse>(donationPost);
            }
            else
            {
                return null;
            }
        }
        public async Task<IEnumerable<DonationPostResponse>> GetByDonationCenter(Guid donationCenterId)
        {
            IEnumerable<DonationPost> donationPosts = await _donationPostRepository.GetByDonationCenter(donationCenterId);
            IEnumerable<DonationPostResponse> response = donationPosts.Select(dp => _mapper.Map<DonationPostResponse>(dp));

            return response;
        }
        public async Task<IEnumerable<DonationPostResponse>> GetByUser(Guid userId)
        {
            IEnumerable<DonationPost> donationPosts = await _donationPostRepository.GetByUser(userId);
            IEnumerable<DonationPostResponse> response = donationPosts.Select(dp => _mapper.Map<DonationPostResponse>(dp));

            return response;
        }
        public async Task<DonationPostResponse> UpdateByUser(Guid userId, Guid donationPostId, DonationPostRequest donationPostRequest)
        {
            DonationPost? donationPost = await _donationPostRepository.GetByUser(userId, donationPostId);
            if(donationPost == null)
            {
                throw new EntityNotFoundException($"Donation Post with ID {donationPostId} not found.");
            }

            DonationPostRequestValidator donationPostRequestValidator = new DonationPostRequestValidator();
            donationPostRequestValidator.ValidateAndThrow(donationPostRequest);

            _mapper.Map(donationPostRequest, donationPost);

            donationPost.Id = donationPostId;
            donationPost.UserId = userId;
            donationPost.UpdatedAt = DateTime.Now;
               
            await _donationPostRepository.Update(donationPost);

            return _mapper.Map<DonationPostResponse>(donationPost);
        }
        public async Task<DonationPostResponse> UpdateByDonationCenter(Guid donationCenterId, Guid donationPostId, DonationPostRequest donationPostRequest)
        {
            DonationPost? donationPost = await _donationPostRepository.GetByDonationCenter(donationCenterId, donationPostId);
            if (donationPost == null)
            {
                throw new EntityNotFoundException($"Donation Post with ID {donationPostId} not found.");
            }

            DonationPostRequestValidator donationPostRequestValidator = new DonationPostRequestValidator();
            donationPostRequestValidator.ValidateAndThrow(donationPostRequest);

            _mapper.Map(donationPostRequest, donationPost);

            donationPost.Id = donationPostId;
            donationPost.DonationCenterId = donationCenterId;
            donationPost.UpdatedAt = DateTime.Now;

            await _donationPostRepository.Update(donationPost);

            return _mapper.Map<DonationPostResponse>(donationPost);
        }
    }
}
