using Moq;
using System.Diagnostics;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Service.Tests.Utilities;
using Umss.BloodOrgansDonationApp.Services;
using static System.Net.Mime.MediaTypeNames;

namespace Umss.BloodOrgansDonationApp.Service.Tests.Services
{
    public class DonationTypeServiceTest: IClassFixture<ServiceFixture>
    {
        private readonly ServiceFixture serviceFixture;
        private readonly DonationTypeService donationTypeService;

        public DonationTypeServiceTest(ServiceFixture serviceFixture)
        {
            this.serviceFixture = serviceFixture;
            this.donationTypeService = new DonationTypeService(this.serviceFixture.DonationTypeRepository);
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
            this.serviceFixture.DonationTypeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(this.GetDonationTypes);
            IEnumerable<DonationType> donationTypes = await this.donationTypeService.GetAll();

            Assert.NotEmpty(donationTypes);
        }

        [Fact]
        public async void GetById()
        {
            this.serviceFixture.DonationTypeRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(this.GetDonationType);
            DonationType donationType = await this.donationTypeService.Get(Guid.NewGuid());

            Assert.NotNull(donationType);
        }

        [Fact]
        public async void Create()
        {
            this.serviceFixture.DonationTypeRepositoryMock.Setup(x => x.Create(It.IsAny<DonationType>())).ReturnsAsync(this.GetDonationType());
            DonationType donationType = await this.donationTypeService.Create(this.GetDonationTypeRequest());

            Assert.NotNull(donationType);
        }

        [Fact]
        public async void Delete()
        {
            this.serviceFixture.DonationTypeRepositoryMock.Setup(x => x.Delete(It.IsAny<Guid>()));
            await this.donationTypeService.Delete(Guid.NewGuid());
        }

        [Fact]
        public async void Update()
        {
            this.serviceFixture.DonationTypeRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(this.GetDonationType());
            this.serviceFixture.DonationTypeRepositoryMock.Setup(x => x.Update(It.IsAny<DonationType>())).ReturnsAsync(this.GetDonationType());
            DonationType donationType = await this.donationTypeService.Update(Guid.NewGuid(), this.GetDonationTypeRequest());

            Assert.NotNull(donationType);
        }
    }
}
