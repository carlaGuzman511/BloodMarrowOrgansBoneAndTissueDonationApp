using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Requests;

namespace Umss.BloodOrgansDonationApp.Services.Interfaces
{
    public interface IDonationCenterService: IDonationAppService<DonationCenterRequest, DonationCenter>
    {
    }
}
