using Microsoft.EntityFrameworkCore;
using Umss.BloodOrgansDonationApp.Repository.Interfaces;
using Umss.BloodOrgansDonationApp.Models;

namespace Umss.BloodOrgansDonationApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DonationAppContext _appContext;
        public UserRepository(DonationAppContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<User> Create(User element)
        {
            await _appContext.AddAsync(element);
            await _appContext.SaveChangesAsync();
            return element;
        }

        //TODO: Implement a soft delete due foreign key issues.
        public async Task Delete(Guid id)
        {
            User? user = await Get(id);
            if (user != null)
            {
                _appContext.Remove(user);
                await _appContext.SaveChangesAsync();
            }
        }

        public async Task<User?> Get(Guid id)
        {
            return await _appContext.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _appContext.Users.ToListAsync();
        }

        public async Task<User> Update(User element)
        {
            await _appContext.SaveChangesAsync();
            return element;
        }
    }
}
