using Moq;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Requests;
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
            this.donationPostService = new DonationPostService(this.repositoryFixture.DonationPostRepository);
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
                DonationCenterId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                DonationTypeId = Guid.NewGuid(),
                Description = "Se necesita sangre tipo: O-",
                Image = String.Empty,
            };
      
            return donationPostRequest;
        }

        [Fact]
        public async void GetAll()
        {
            this.repositoryFixture.DonationPostRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(this.GetDonationPosts());
            var donationPosts = await this.donationPostService.GetAll();

            Assert.NotEmpty(donationPosts);
        }

        [Fact]
        public async void GetById()
        {
            this.repositoryFixture.DonationPostRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(this.GetDonationPost());
            var donationPost = await this.donationPostService.Get(Guid.NewGuid());

            Assert.NotNull(donationPost);
        }

        [Fact]
        public async void Create()
        {
            this.repositoryFixture.DonationPostRepositoryMock.Setup(x => x.Create(It.IsAny<DonationPost>())).ReturnsAsync(this.GetDonationPost());
            DonationPost donationPost = await this.donationPostService.Create(this.GetDonationPostRequest());

            Assert.NotNull(donationPost);
        }

        [Fact]
        public async void Delete()
        {
            this.repositoryFixture.DonationPostRepositoryMock.Setup(x => x.Delete(It.IsAny<Guid>()));
            await this.donationPostService.Delete(Guid.NewGuid());
        }

        [Fact]
        public async void Update()
        {
            this.repositoryFixture.DonationPostRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(this.GetDonationPost());
            this.repositoryFixture.DonationPostRepositoryMock.Setup(x => x.Update(It.IsAny<DonationPost>())).ReturnsAsync(this.GetDonationPost());
            DonationPost donationPost = await this.donationPostService.Update(Guid.NewGuid(), this.GetDonationPostRequest());

            Assert.NotNull(donationPost);
        }
    }
}
