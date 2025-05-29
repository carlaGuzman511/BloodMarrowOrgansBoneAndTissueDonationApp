using Umss.BloodOrgansDonationApp.Models;

namespace Umss.BloodOrgansDonationApp.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user, IEnumerable<string> roles);
    }
}
