using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Requests;

namespace Umss.BloodOrgansDonationApp.Services.Interfaces
{
    public interface IBloodTypeService: IDonationAppService<BloodTypeRequest, BloodType>
    {
    }
}
