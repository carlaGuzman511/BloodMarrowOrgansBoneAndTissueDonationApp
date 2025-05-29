using Umss.BloodOrgansDonationApp.API.Controllers;
using Umss.BloodOrgansDonationApp.API.Tests.Utilities;

namespace Umss.BloodOrgansDonationApp.API.Tests.Controllers
{
    public class DonationPostControllerTest: IClassFixture<ServiceFixture>
    {
        private readonly ServiceFixture serviceFixture;
        private readonly DonationPostController donationPostController;

        public DonationPostControllerTest(ServiceFixture serviceFixture)
        {
            this.serviceFixture = serviceFixture;
            this.donationPostController = new DonationPostController(this.serviceFixture.DonationPostService);
        }
    }
}
