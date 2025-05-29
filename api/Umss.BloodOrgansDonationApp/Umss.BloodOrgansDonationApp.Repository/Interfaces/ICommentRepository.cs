using Umss.BloodOrgansDonationApp.Models.Entities;

namespace Umss.BloodOrgansDonationApp.Repository.Interfaces
{
    public interface ICommentRepository
    {
        public Task<IEnumerable<Comment>> Get(Guid donationPostId);
        public Task<Comment?> Get(Guid donationPostId, Guid commentId);
        public Task<Comment> Create(Comment comment);
        public Task<Comment> Update(Comment comment);
        public Task Delete(Guid donationPostId, Guid commentId);
    }
}
