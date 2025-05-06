using Umss.BloodOrgansDonationApp.API.Controllers;
using Umss.BloodOrgansDonationApp.API.Tests.Utilities;

namespace Umss.BloodOrgansDonationApp.API.Tests.Controllers
{
    public class BloodTypeControllerTest: IClassFixture<ServiceFixture>
    {
        private readonly BloodTypeController bloodTypeController;
        private readonly ServiceFixture serviceFixture;

        public BloodTypeControllerTest(ServiceFixture serviceFixture)
        {
            this.serviceFixture = serviceFixture;
            this.bloodTypeController = new BloodTypeController(serviceFixture.BloodTypeService);
        }
    }
}
