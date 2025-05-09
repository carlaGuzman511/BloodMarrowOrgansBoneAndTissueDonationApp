using Moq;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Service.Tests.Utilities;
using Umss.BloodOrgansDonationApp.Services;

namespace Umss.BloodOrgansDonationApp.Service.Tests.Services
{
    public class DonationCenterServiceTest : IClassFixture<RepositoryFixture>
    {
        private readonly RepositoryFixture repositoryFixture;
        private readonly DonationCenterService donationCenterService;
        public DonationCenterServiceTest(RepositoryFixture repositoryFixture)
        {
            this.repositoryFixture = repositoryFixture;
            this.donationCenterService = new DonationCenterService(repositoryFixture.DonationCenterRepository);
        }

        private IEnumerable<DonationCenter> GetDonationCenters()
        {
            DonationCenter[] donationCenters = new DonationCenter[8] {
                new DonationCenter { Id = Guid.NewGuid(), Name = "Viedma Hospital", Address = "Av Blanco Galindo Km 6", City = "Cochabamba - Bolivia" },
                new DonationCenter { Id = Guid.NewGuid(), Name = "Belga Hospital", Address = "Av Blanco Galindo Km 6", City = "Cochabamba - Bolivia" },
                new DonationCenter { Id = Guid.NewGuid(), Name = "Univalle Hospital", Address = "Av Blanco Galindo Km 6", City = "Cochabamba - Bolivia" },
                new DonationCenter { Id = Guid.NewGuid(), Name = "ProSalud Hospital", Address = "Av Blanco Galindo Km 6", City = "Cochabamba - Bolivia" },
                new DonationCenter { Id = Guid.NewGuid(), Name = "Materno Infantil Hospital", Address = "Av Blanco Galindo Km 6", City = "Cochabamba - Bolivia" },
                new DonationCenter { Id = Guid.NewGuid(), Name = "Obrero Hospital", Address = "Av Blanco Galindo Km 6", City = "Cochabamba - Bolivia" },
                new DonationCenter { Id = Guid.NewGuid(), Name = "Cotahuma Hospital", Address = "Av Blanco Galindo Km 6", City = "Cochabamba - Bolivia" },
                new DonationCenter { Id = Guid.NewGuid(), Name = "Clinicas Hospital", Address = "Av Blanco Galindo Km 6", City = "Cochabamba - Bolivia" },
            };

            return donationCenters;
        }

        private DonationCenter GetDonationCenter()
        {
            var donationCenter = new DonationCenter { Id = Guid.NewGuid(), Name = "Viedma Hospital", Address = "Av Blanco Galindo Km 6", City = "Cochabamba - Bolivia" };

            return donationCenter;
        }

        private DonationCenterRequest GetDonationCenterRequest()
        {
            var donationCenterRequest = new DonationCenterRequest
            {
                Name = "Viedma Hospital",
                Address = "Av. Blanco Galindo Km 6",
                City = "Cochabamba - Bolivia",
                DonationTypes = new List<DonationType>(),
            };

            return donationCenterRequest;
        }
        [Fact]
        public async void GetAll()
        {
            this.repositoryFixture.DonationCenterRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(this.GetDonationCenters());
            var donationCenters = await this.donationCenterService.GetAll();

            Assert.NotEmpty(donationCenters);
        }

        [Fact]
        public async void GetById()
        {
            this.repositoryFixture.DonationCenterRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(this.GetDonationCenter());
            var donationCenter = await this.donationCenterService.Get(Guid.NewGuid());

            Assert.NotNull(donationCenter);
        }


        [Fact]
        public async void Create()
        {
            this.repositoryFixture.DonationCenterRepositoryMock.Setup(x => x.Create(It.IsAny<DonationCenter>())).ReturnsAsync(this.GetDonationCenter);
            DonationCenter donationCenter = await this.donationCenterService.Create(this.GetDonationCenterRequest());

            Assert.NotNull(donationCenter);
        }

        [Fact]
        public async void Delete()
        {
            this.repositoryFixture.CommentRepositoryMock.Setup(x => x.Delete(It.IsAny<Guid>()));
            await this.donationCenterService.Delete(Guid.NewGuid());
        }

        [Fact]
        public async void Update()
        {
            this.repositoryFixture.DonationCenterRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(this.GetDonationCenter());
            this.repositoryFixture.DonationCenterRepositoryMock.Setup(x => x.Update(It.IsAny<DonationCenter>())).ReturnsAsync(this.GetDonationCenter());
            DonationCenter donationCenter = await this.donationCenterService.Update(Guid.NewGuid(), this.GetDonationCenterRequest());

            Assert.NotNull(donationCenter);
        }
    }
}
