using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;

namespace Umss.BloodOrgansDonationApp.Services.Interfaces
{
    public interface IUserService: IDonationAppService<UserRequest, UserResponse>
    {
        Task<AuthResponse> LoginAsync(LoginRequest loginRequest);
    }
}
