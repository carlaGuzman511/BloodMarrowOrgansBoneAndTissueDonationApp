using Umss.BloodOrgansDonationApp.Models;

namespace Umss.BloodOrgansDonationApp.Repository.Interfaces
{
    public interface IUserRepository: IDonationAppRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<IEnumerable<string>> GetRolesAsync(User user);
    }
}
