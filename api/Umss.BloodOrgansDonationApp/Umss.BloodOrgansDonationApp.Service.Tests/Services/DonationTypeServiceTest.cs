using Moq;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;
using Umss.BloodOrgansDonationApp.Service.Tests.Utilities;
using Umss.BloodOrgansDonationApp.Services;

namespace Umss.BloodOrgansDonationApp.Service.Tests.Services
{
    public class DonationTypeServiceTest: IClassFixture<RepositoryFixture>
    {
        private readonly RepositoryFixture repositoryFixture;
        private readonly DonationTypeService donationTypeService;

        public DonationTypeServiceTest(RepositoryFixture repositoryFixture)
        {
            this.repositoryFixture = repositoryFixture;
            this.donationTypeService = new DonationTypeService(this.repositoryFixture.DonationTypeRepository, this.repositoryFixture.Mapper);
        }
        private IEnumerable<DonationType> GetDonationTypes() 
        {
            DonationType[] donationTypes = new DonationType[8]
            {
                new DonationType {Id = Guid.NewGuid(), Name = "Blood Donation", Description = "Blood Donation", Requirements = "Blood Donation", Process = "Blood Donation", Importance = "Blood Donation", Benefits = "Blood Donation", SecondaryEffects = "Blood Donation", Image = String.Empty},
                new DonationType {Id = Guid.NewGuid(), Name = "Blood Donation", Description = "Blood Donation", Requirements = "Blood Donation", Process = "Blood Donation", Importance = "Blood Donation", Benefits = "Blood Donation", SecondaryEffects = "Blood Donation", Image = String.Empty},
                new DonationType {Id = Guid.NewGuid(), Name = "Blood Donation", Description = "Blood Donation", Requirements = "Blood Donation", Process = "Blood Donation", Importance = "Blood Donation", Benefits = "Blood Donation", SecondaryEffects = "Blood Donation", Image = String.Empty},
                new DonationType {Id = Guid.NewGuid(), Name = "Blood Donation", Description = "Blood Donation", Requirements = "Blood Donation", Process = "Blood Donation", Importance = "Blood Donation", Benefits = "Blood Donation", SecondaryEffects = "Blood Donation", Image = String.Empty},
                new DonationType {Id = Guid.NewGuid(), Name = "Blood Donation", Description = "Blood Donation", Requirements = "Blood Donation", Process = "Blood Donation", Importance = "Blood Donation", Benefits = "Blood Donation", SecondaryEffects = "Blood Donation", Image = String.Empty},
                new DonationType {Id = Guid.NewGuid(), Name = "Blood Donation", Description = "Blood Donation", Requirements = "Blood Donation", Process = "Blood Donation", Importance = "Blood Donation", Benefits = "Blood Donation", SecondaryEffects = "Blood Donation", Image = String.Empty},
                new DonationType {Id = Guid.NewGuid(), Name = "Blood Donation", Description = "Blood Donation", Requirements = "Blood Donation", Process = "Blood Donation", Importance = "Blood Donation", Benefits = "Blood Donation", SecondaryEffects = "Blood Donation", Image = String.Empty},
                new DonationType {Id = Guid.NewGuid(), Name = "Blood Donation", Description = "Blood Donation", Requirements = "Blood Donation", Process = "Blood Donation", Importance = "Blood Donation", Benefits = "Blood Donation", SecondaryEffects = "Blood Donation", Image = String.Empty},
            };

            return donationTypes;
        }
        private DonationType GetDonationType()
        {
            DonationType donationType = new DonationType { Id = Guid.NewGuid(), Name = "Blood Donation", Description = "Blood Donation", Requirements = "Blood Donation", Process = "Blood Donation", Importance = "Blood Donation", Benefits = "Blood Donation", SecondaryEffects = "Blood Donation", Image = String.Empty };
            
            return donationType;
        }

        private DonationTypeRequest GetDonationTypeRequest() 
        {
            DonationTypeRequest donationTypeRequest = new DonationTypeRequest
            {
                Name = "Blood Donation",
                Description = string.Empty,
                Requirements = string.Empty,
                Process = string.Empty,
                Importance = string.Empty,
                Benefits = string.Empty,
                SecondaryEffects = string.Empty,
                Image = string.Empty,
            };

            return donationTypeRequest;
        }
        
        [Fact]
        public async void GetAll()
        {
            this.repositoryFixture.DonationTypeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(this.GetDonationTypes);
            IEnumerable<DonationTypeResponse> donationTypes = await this.donationTypeService.GetAll();

            Assert.NotEmpty(donationTypes);
        }

        [Fact]
        public async void GetById()
        {
            this.repositoryFixture.DonationTypeRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(this.GetDonationType);
            DonationTypeResponse donationType = await this.donationTypeService.Get(Guid.NewGuid());

            Assert.NotNull(donationType);
        }

        [Fact]
        public async void Create()
        {
            this.repositoryFixture.DonationTypeRepositoryMock.Setup(x => x.Create(It.IsAny<DonationType>())).ReturnsAsync(this.GetDonationType());
            DonationTypeResponse donationType = await this.donationTypeService.Create(this.GetDonationTypeRequest());

            Assert.NotNull(donationType);
        }

        [Fact]
        public async void Delete()
        {
            this.repositoryFixture.DonationTypeRepositoryMock.Setup(x => x.Delete(It.IsAny<Guid>()));
            await this.donationTypeService.Delete(Guid.NewGuid());
        }

        [Fact]
        public async void Update()
        {
            this.repositoryFixture.DonationTypeRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(this.GetDonationType());
            this.repositoryFixture.DonationTypeRepositoryMock.Setup(x => x.Update(It.IsAny<DonationType>())).ReturnsAsync(this.GetDonationType());
            DonationTypeResponse donationType = await this.donationTypeService.Update(Guid.NewGuid(), this.GetDonationTypeRequest());

            Assert.NotNull(donationType);
        }
    }
}
