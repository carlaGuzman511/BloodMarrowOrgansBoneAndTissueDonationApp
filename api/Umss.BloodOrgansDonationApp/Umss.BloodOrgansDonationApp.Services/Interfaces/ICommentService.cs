namespace Umss.BloodOrgansDonationApp.Services.Interfaces
{
    public interface ICommentService<CommentRequest, CommentResponse>
    {
        public Task<IEnumerable<CommentResponse>> Get(Guid DonationPostId);
        public Task<CommentResponse?> Get(Guid DonationPostId, Guid commentId);
        public Task<CommentResponse> Create(Guid DonationPostId, CommentRequest commentRequest);
        public Task<CommentResponse> Update(Guid DonationPostId, Guid commentId, CommentRequest commentRequest);
        public Task Delete(Guid DonationPostId, Guid commentId);
    }
}
