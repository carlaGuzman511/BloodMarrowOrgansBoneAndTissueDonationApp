using AutoMapper;
using FluentValidation;
using Umss.BloodOrgansDonationApp.Models.Entities;
using Umss.BloodOrgansDonationApp.Models.Exceptions;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;
using Umss.BloodOrgansDonationApp.Repository.Interfaces;
using Umss.BloodOrgansDonationApp.Services.Interfaces;
using Umss.BloodOrgansDonationApp.Services.Validators;

namespace Umss.BloodOrgansDonationApp.Services
{
    public class CommentService : ICommentService<CommentRequest, CommentResponse>
    {
        private readonly ICommentRepository<Comment> _commentRepository;
        private readonly IMapper _mapper;
        public CommentService(ICommentRepository<Comment> commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<CommentResponse> Create(Guid donationPostId, CommentRequest commentRequest)
        {
            CommentRequestValidator commentRequestValidator = new CommentRequestValidator();
            commentRequestValidator.ValidateAndThrow(commentRequest);

            Comment comment = _mapper.Map<Comment>(commentRequest);
            comment.Id = Guid.NewGuid();
            comment.CreatedAt = DateTime.UtcNow;
            comment.DonationPostId = donationPostId;

            comment = await _commentRepository.Create(comment);

            return _mapper.Map<CommentResponse>(comment);
        }

        public async Task Delete(Guid donationPostId, Guid commentId)
        {
            await _commentRepository.Delete(donationPostId, commentId);
        }

        public async Task<CommentResponse?> Get(Guid donationPostId, Guid commentId)
        {
            Comment? comment = await _commentRepository.Get(donationPostId, commentId);
            if (comment != null) 
            {
                return _mapper.Map<CommentResponse>(comment);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<CommentResponse>> Get(Guid donationPostId)
        {
            IEnumerable<Comment> comments = await _commentRepository.Get(donationPostId);
            IEnumerable<CommentResponse> response = comments.Select(x => _mapper.Map<CommentResponse>(x));

            return response;
        }
        public async Task<CommentResponse> Update(Guid donationPostId, Guid commentId, CommentRequest commentRequest)
        {
            Comment? comment = await _commentRepository.Get(donationPostId, commentId);
            if (comment == null)
            {
                throw new EntityNotFoundException($"Comment with ID {commentId} from post ID {donationPostId} not found.");
            }

            CommentRequestValidator commentRequestValidator = new CommentRequestValidator();
            commentRequestValidator.ValidateAndThrow(commentRequest);

            _mapper.Map(commentRequest, comment);
            comment.UpdatedAt = DateTime.Now;
            comment.DonationPostId = donationPostId;
            comment.Id = commentId;

            comment = await _commentRepository.Update(comment);

            return _mapper.Map<CommentResponse>(comment);
        }
    }
}
