using AutoMapper;
using Moq;
using Umss.BloodOrgansDonationApp.Repository.Interfaces;
using Umss.BloodOrgansDonationApp.Services.Interfaces;

namespace Umss.BloodOrgansDonationApp.Service.Tests.Utilities
{
    public class RepositoryFixture
    {
        protected internal Mock<IUserRepository> UserRepositoryMock { get; }
        protected internal Mock<ICommentRepository> CommentRepositoryMock { get; }
        protected internal Mock<IDonationTypeRepository> DonationTypeRepositoryMock { get; }
        protected internal Mock<IDonationPostRepository> DonationPostRepositoryMock { get; }
        protected internal Mock<IBloodTypeRepository> BloodTypeRepositoryMock { get; }
        protected internal Mock<IDonationCenterRepository> DonationCenterRepositoryMock { get; }
        protected internal Mock<IMapper> MapperMock { get; }
        protected internal Mock<ITokenService> tokenServiceMock { get; }

        protected internal IUserRepository UserRepository { get; }
        protected internal ICommentRepository CommentRepository { get; }
        protected internal IDonationTypeRepository DonationTypeRepository { get; }
        protected internal IDonationPostRepository DonationPostRepository { get; }
        protected internal IBloodTypeRepository BloodTypeRepository { get; }
        protected internal IDonationCenterRepository DonationCenterRepository { get; }
        protected internal IMapper Mapper { get; }
        protected internal ITokenService tokenService {  get; }

        public RepositoryFixture()
        {
            this.BloodTypeRepositoryMock = new Mock<IBloodTypeRepository>();
            this.BloodTypeRepository = this.BloodTypeRepositoryMock.Object;

            this.DonationCenterRepositoryMock = new Mock<IDonationCenterRepository>();
            this.DonationCenterRepository = this.DonationCenterRepositoryMock.Object;

            this.DonationPostRepositoryMock = new Mock<IDonationPostRepository>();
            this.DonationPostRepository = this.DonationPostRepositoryMock.Object;

            this.CommentRepositoryMock = new Mock<ICommentRepository>();
            this.CommentRepository = this.CommentRepositoryMock.Object;

            this.DonationTypeRepositoryMock = new Mock<IDonationTypeRepository>();
            this.DonationTypeRepository = this.DonationTypeRepositoryMock.Object;

            this.UserRepositoryMock = new Mock<IUserRepository>();
            this.UserRepository = this.UserRepositoryMock.Object;

            this.MapperMock = new Mock<IMapper>();
            this.Mapper = this.MapperMock.Object;

            this.tokenServiceMock = new Mock<ITokenService>();
            this.tokenService = this.tokenServiceMock.Object;
        }
    }
}
