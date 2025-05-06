using Moq;
using Umss.BloodOrgansDonationApp.Services.Interfaces;

namespace Umss.BloodOrgansDonationApp.API.Tests.Utilities
{
    public class ServiceFixture
    {
        protected internal Mock<IUserService> UserServiceMock { get; }
        protected internal Mock<ICommentService> CommentServiceMock { get; }
        protected internal Mock<IDonationTypeService> DonationTypeServiceMock { get; }
        protected internal Mock<IDonationPostService> DonationPostServiceMock { get; }
        protected internal Mock<IBloodTypeService> BloodTypeServiceMock { get; }
        protected internal Mock<IDonationCenterService> DonationCenterServiceMock { get; }

        protected internal IUserService UserService { get; }
        protected internal ICommentService CommentService { get; }
        protected internal IDonationTypeService DonationTypeService { get; }
        protected internal IDonationPostService DonationPostService { get; }
        protected internal IBloodTypeService BloodTypeService { get; }
        protected internal IDonationCenterService DonationCenterService { get; }

        public ServiceFixture()
        {
            this.BloodTypeServiceMock = new Mock<IBloodTypeService>();
            this.BloodTypeService = this.BloodTypeServiceMock.Object;

            this.DonationCenterServiceMock = new Mock<IDonationCenterService>();
            this.DonationCenterService = this.DonationCenterServiceMock.Object;

            this.DonationPostServiceMock = new Mock<IDonationPostService>();
            this.DonationPostService = this.DonationPostServiceMock.Object;

            this.CommentServiceMock = new Mock<ICommentService>();
            this.CommentService = this.CommentServiceMock.Object;

            this.DonationTypeServiceMock = new Mock<IDonationTypeService>();
            this.DonationTypeService = this.DonationTypeServiceMock.Object;

            this.UserServiceMock = new Mock<IUserService>();
            this.UserService = this.UserServiceMock.Object;
        }
    }
}
