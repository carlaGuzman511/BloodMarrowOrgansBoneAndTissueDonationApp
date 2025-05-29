using Umss.BloodOrgansDonationApp.API.Controllers;
using Umss.BloodOrgansDonationApp.API.Tests.Utilities;

namespace Umss.BloodOrgansDonationApp.API.Tests.Controllers
{
    public class CommentControllerTest: IClassFixture<ServiceFixture>
    {
        protected readonly CommentController commentController;
        protected readonly ServiceFixture serviceFixture;
        public CommentControllerTest(ServiceFixture serviceFixture)
        {
            this.serviceFixture = serviceFixture;
            this.commentController = new CommentController(this.serviceFixture.CommentService);
        }
    }
}
