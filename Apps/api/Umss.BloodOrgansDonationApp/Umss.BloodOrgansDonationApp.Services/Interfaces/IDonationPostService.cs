using Umss.BloodOrgansDonationApp.Models.Responses;
using Umss.BloodOrgansDonationApp.Models.Requests;

namespace Umss.BloodOrgansDonationApp.Services.Interfaces
{
    public interface IDonationPostService: IDonationAppService<DonationPostRequest, DonationPostResponse>
    {
    }
}
