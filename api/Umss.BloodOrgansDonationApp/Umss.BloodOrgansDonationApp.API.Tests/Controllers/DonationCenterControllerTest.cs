using Umss.BloodOrgansDonationApp.API.Controllers;
using Umss.BloodOrgansDonationApp.API.Tests.Utilities;

namespace Umss.BloodOrgansDonationApp.API.Tests.Controllers
{
    public class DonationCenterControllerTest: IClassFixture<ServiceFixture>
    {
        protected readonly ServiceFixture serviceFixture;
        protected readonly DonationCenterController donationCenterController;

        public DonationCenterControllerTest(ServiceFixture serviceFixture)
        {
            this.serviceFixture = serviceFixture;
            this.donationCenterController = new DonationCenterController(this.serviceFixture.DonationCenterService);
        }
    }
}
