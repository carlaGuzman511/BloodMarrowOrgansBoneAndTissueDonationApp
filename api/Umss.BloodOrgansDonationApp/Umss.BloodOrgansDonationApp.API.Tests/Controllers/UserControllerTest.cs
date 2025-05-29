using Umss.BloodOrgansDonationApp.API.Controllers;
using Umss.BloodOrgansDonationApp.API.Tests.Utilities;

namespace Umss.BloodOrgansDonationApp.API.Tests.Controllers
{
    public class UserControllerTest: IClassFixture<ServiceFixture>
    {
        private readonly ServiceFixture serviceFixture;
        private readonly UserController userController;

        public UserControllerTest(ServiceFixture serviceFixture)
        {
            this.serviceFixture = serviceFixture;
            this.userController = new UserController(this.serviceFixture.UserService);
        }
    }
}
