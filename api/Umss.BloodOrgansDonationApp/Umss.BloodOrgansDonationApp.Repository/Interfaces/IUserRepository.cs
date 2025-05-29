using Umss.BloodOrgansDonationApp.Models;

namespace Umss.BloodOrgansDonationApp.Repository.Interfaces
{
    public interface IUserRepository: IDonationAppRepository<User>
    {
        Task<User> GetByUsernameAsync(string username);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<IList<string>> GetRolesAsync(User user);
    }
}
