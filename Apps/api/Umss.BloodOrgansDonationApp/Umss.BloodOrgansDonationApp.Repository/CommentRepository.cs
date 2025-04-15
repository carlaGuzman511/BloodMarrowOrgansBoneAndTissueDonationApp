using Microsoft.EntityFrameworkCore;
using Umss.BloodOrgansDonationApp.Models.Entities;
using Umss.BloodOrgansDonationApp.Repository.Interfaces;

namespace Umss.BloodOrgansDonationApp.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DonationAppContext _appContext;
        public CommentRepository(DonationAppContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<Comment> Create(Comment element)
        {
            await _appContext.AddAsync(element);
            await _appContext.SaveChangesAsync();
            return element;
        }

        public async Task Delete(Guid id)
        {
            var comment = Get(id);
            if (comment != null) 
            { 
                _appContext.Remove(comment);
            }

            await _appContext.SaveChangesAsync();
        }

        public async Task<Comment> Get(Guid id)
        {
            return await _appContext.Comments.FindAsync(id);
        }

        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await _appContext.Comments.ToListAsync();
        }

        public async Task<Comment> Update(Comment element)
        {
            _appContext.Update(element);
            await _appContext.SaveChangesAsync();
            return element;
        }
    }
}
