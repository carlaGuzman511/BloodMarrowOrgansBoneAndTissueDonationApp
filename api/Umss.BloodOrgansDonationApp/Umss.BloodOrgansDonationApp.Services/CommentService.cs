using Umss.BloodOrgansDonationApp.Models.Entities;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;
using Umss.BloodOrgansDonationApp.Repository.Interfaces;
using Umss.BloodOrgansDonationApp.Services.Interfaces;

namespace Umss.BloodOrgansDonationApp.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<CommentResponse> Create(CommentRequest commentRequest)
        {
            var comment = new Comment
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                DonationPostId = commentRequest.DonationPostId,
                Description = commentRequest.Description,
            };
            await _commentRepository.Create(comment);

            var response = new CommentResponse
            {
                Id = comment.Id,
                CreatedAt = comment.CreatedAt,
                UpdatedAt = comment.UpdatedAt,
                Description = comment.Description,
                DonationPostId= commentRequest.DonationPostId,
            };

            return response;
        }

        public async Task Delete(Guid id)
        {
            var comment = await _commentRepository.Get(id);
            if (comment != null)
            {
                await _commentRepository.Delete(id);
            }
            else
            {
                throw new Exception("");
            }
        }

        public async Task<CommentResponse> Get(Guid id)
        {
            var comment = await _commentRepository.Get(id);
            if (comment != null) 
            {
                var response = new CommentResponse 
                { 
                    Description = comment.Description,
                    CreatedAt = comment.CreatedAt,
                    UpdatedAt = comment.UpdatedAt,
                    Id = comment.Id,
                    DonationPostId = comment.DonationPostId,
                };

                return response;
            }
            else
            {
                throw new Exception("");
            }
        }

        public async Task<IEnumerable<CommentResponse>> GetAll()
        {
            var comments = await _commentRepository.GetAll();
            var response = comments.Select(x => new CommentResponse{
                Id = x.Id,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                DonationPostId = x.DonationPostId,
            });

            return response;
        }

        public async Task<CommentResponse> Update(Guid id, CommentRequest element)
        {
            var comment = await _commentRepository.Get(id);
            if (comment != null)
            {
                comment.Description = element.Description;
                comment.UpdatedAt = DateTime.Now;
                comment.DonationPostId = element.DonationPostId;

                await _commentRepository.Update(comment);
                var response = await Get(comment.Id);

                return response;
            }
            else
            {
                throw new Exception("");
            }
        }
    }
}
