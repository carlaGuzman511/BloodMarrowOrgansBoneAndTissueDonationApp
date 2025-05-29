using Moq;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;
using Umss.BloodOrgansDonationApp.Service.Tests.Utilities;
using Umss.BloodOrgansDonationApp.Services;

namespace Umss.BloodOrgansDonationApp.Service.Tests.Services
{
    public class DonationPostServiceTest : IClassFixture<RepositoryFixture>
    {
        private readonly DonationPostService donationPostService;
        private readonly RepositoryFixture repositoryFixture;

        public DonationPostServiceTest(RepositoryFixture repositoryFixture)
        {
            this.repositoryFixture = repositoryFixture;
            this.donationPostService = new DonationPostService(this.repositoryFixture.DonationPostRepository, this.repositoryFixture.Mapper);
        }
        private IEnumerable<DonationPost> GetDonationPosts()
        {
            DonationPost[] donationPosts = new DonationPost[8]
            {
                new DonationPost {Id = Guid.NewGuid(), BloodTypeId = Guid.NewGuid(), DonationTypeId = Guid.NewGuid(), UserId = Guid.NewGuid(), DonationCenterId = Guid.NewGuid(), CreatedAt = DateTime.Now, Description = "Se busca donante de sangre tipo: O-", Image = String.Empty },
                new DonationPost {Id = Guid.NewGuid(), BloodTypeId = Guid.NewGuid(), DonationTypeId = Guid.NewGuid(), UserId = Guid.NewGuid(), DonationCenterId = Guid.NewGuid(), CreatedAt = DateTime.Now, Description = "Se busca donante de sangre tipo: O-", Image = String.Empty },
                new DonationPost {Id = Guid.NewGuid(), BloodTypeId = Guid.NewGuid(), DonationTypeId = Guid.NewGuid(), UserId = Guid.NewGuid(), DonationCenterId = Guid.NewGuid(), CreatedAt = DateTime.Now, Description = "Se busca donante de sangre tipo: O-", Image = String.Empty },
                new DonationPost {Id = Guid.NewGuid(), BloodTypeId = Guid.NewGuid(), DonationTypeId = Guid.NewGuid(), UserId = Guid.NewGuid(), DonationCenterId = Guid.NewGuid(), CreatedAt = DateTime.Now, Description = "Se busca donante de sangre tipo: O-", Image = String.Empty },
                new DonationPost {Id = Guid.NewGuid(), BloodTypeId = Guid.NewGuid(), DonationTypeId = Guid.NewGuid(), UserId = Guid.NewGuid(), DonationCenterId = Guid.NewGuid(), CreatedAt = DateTime.Now, Description = "Se busca donante de sangre tipo: O-", Image = String.Empty },
                new DonationPost {Id = Guid.NewGuid(), BloodTypeId = Guid.NewGuid(), DonationTypeId = Guid.NewGuid(), UserId = Guid.NewGuid(), DonationCenterId = Guid.NewGuid(), CreatedAt = DateTime.Now, Description = "Se busca donante de sangre tipo: O-", Image = String.Empty },
                new DonationPost {Id = Guid.NewGuid(), BloodTypeId = Guid.NewGuid(), DonationTypeId = Guid.NewGuid(), UserId = Guid.NewGuid(), DonationCenterId = Guid.NewGuid(), CreatedAt = DateTime.Now, Description = "Se busca donante de sangre tipo: O-", Image = String.Empty },
                new DonationPost {Id = Guid.NewGuid(), BloodTypeId = Guid.NewGuid(), DonationTypeId = Guid.NewGuid(), UserId = Guid.NewGuid(), DonationCenterId = Guid.NewGuid(), CreatedAt = DateTime.Now, Description = "Se busca donante de sangre tipo: O-", Image = String.Empty },
            };

            return donationPosts;
        }

        private DonationPost GetDonationPost()
        {
            DonationPost donationPost = new DonationPost { Id = Guid.NewGuid(), BloodTypeId = Guid.NewGuid(), DonationTypeId = Guid.NewGuid(), UserId = Guid.NewGuid(), DonationCenterId = Guid.NewGuid(), CreatedAt = DateTime.Now, Description = "Se busca donante de sangre tipo: O-", Image = String.Empty };

            return donationPost;
        }

        private DonationPostRequest GetDonationPostRequest()
        {
            DonationPostRequest donationPostRequest = new DonationPostRequest()
            {
                BloodTypeId = Guid.NewGuid(),
                DonationTypeId = Guid.NewGuid(),
                Description = "Se necesita sangre tipo: O-",
                Image = String.Empty,
            };
      
            return donationPostRequest;
        }

        [Fact]
        public async void GetByDonationCenterId()
        {
            this.repositoryFixture.DonationPostRepositoryMock.Setup(x => x.GetByDonationCenter(It.IsAny<Guid>())).ReturnsAsync(this.GetDonationPosts());
            IEnumerable<DonationPostResponse> donationPosts = await this.donationPostService.GetByDonationCenter(Guid.NewGuid());

            Assert.NotEmpty(donationPosts);
        }

        [Fact]
        public async void GetByUserId()
        {
            this.repositoryFixture.DonationPostRepositoryMock.Setup(x => x.GetByUser(It.IsAny<Guid>())).ReturnsAsync(this.GetDonationPosts());
            IEnumerable<DonationPostResponse> donationPosts = await this.donationPostService.GetByUser(Guid.NewGuid());

            Assert.NotEmpty(donationPosts);
        }

        [Fact]
        public async void GetByDonationCenterIdAndPostId()
        {
            this.repositoryFixture.DonationPostRepositoryMock.Setup(x => x.GetByDonationCenter(It.IsAny<Guid>(), It.IsAny<Guid>())).ReturnsAsync(this.GetDonationPost());
            DonationPostResponse? donationPost = await this.donationPostService.GetByDonationCenter(Guid.NewGuid(), Guid.NewGuid());

            Assert.NotNull(donationPost);
        }

        [Fact]
        public async void GetByUserIdAndPostId()
        {
            this.repositoryFixture.DonationPostRepositoryMock.Setup(x => x.GetByUser(It.IsAny<Guid>(), It.IsAny<Guid>())).ReturnsAsync(this.GetDonationPost());
            DonationPostResponse? donationPost = await this.donationPostService.GetByUser(Guid.NewGuid(), Guid.NewGuid());

            Assert.NotNull(donationPost);
        }

        [Fact]
        public async void CreateByDonationCenterId()
        {
            this.repositoryFixture.DonationPostRepositoryMock.Setup(x => x.Create(It.IsAny<DonationPost>())).ReturnsAsync(this.GetDonationPost());
            DonationPostResponse donationPost = await this.donationPostService.CreateByDonationCenter(Guid.NewGuid(), this.GetDonationPostRequest());

            Assert.NotNull(donationPost);
        }

        [Fact]
        public async void CreateByUserId()
        {
            this.repositoryFixture.DonationPostRepositoryMock.Setup(x => x.Create(It.IsAny<DonationPost>())).ReturnsAsync(this.GetDonationPost());
            DonationPostResponse donationPost = await this.donationPostService.CreateByUser(Guid.NewGuid(), this.GetDonationPostRequest());

            Assert.NotNull(donationPost);
        }

        [Fact]
        public async void DeleteByUserId()
        {
            this.repositoryFixture.DonationPostRepositoryMock.Setup(x => x.DeleteByUser(It.IsAny<Guid>(), It.IsAny<Guid>()));
            await this.donationPostService.DeleteByUser(Guid.NewGuid(), Guid.NewGuid());
        }

        [Fact]
        public async void DeleteByDonationCenterId()
        {
            this.repositoryFixture.DonationPostRepositoryMock.Setup(x => x.DeleteByDonationCenter(It.IsAny<Guid>(), It.IsAny<Guid>()));
            await this.donationPostService.DeleteByDonationCenter(Guid.NewGuid(), Guid.NewGuid());
        }

        [Fact]
        public async void UpdateByDonationCenterId()
        {
            this.repositoryFixture.DonationPostRepositoryMock.Setup(x => x.GetByDonationCenter(It.IsAny<Guid>(), It.IsAny<Guid>())).ReturnsAsync(this.GetDonationPost());
            this.repositoryFixture.DonationPostRepositoryMock.Setup(x => x.Update(It.IsAny<DonationPost>())).ReturnsAsync(this.GetDonationPost());
            DonationPostResponse donationPost = await this.donationPostService.UpdateByDonationCenter(Guid.NewGuid(), Guid.NewGuid(), this.GetDonationPostRequest());

            Assert.NotNull(donationPost);
        }

        [Fact]
        public async void UpdateByUserId()
        {
            this.repositoryFixture.DonationPostRepositoryMock.Setup(x => x.GetByUser(It.IsAny<Guid>(), It.IsAny<Guid>())).ReturnsAsync(this.GetDonationPost());
            this.repositoryFixture.DonationPostRepositoryMock.Setup(x => x.Update(It.IsAny<DonationPost>())).ReturnsAsync(this.GetDonationPost());
            DonationPostResponse donationPost = await this.donationPostService.UpdateByUser(Guid.NewGuid(), Guid.NewGuid(), this.GetDonationPostRequest());

            Assert.NotNull(donationPost);
        }
    }
}
