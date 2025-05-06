using Moq;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Service.Tests.Utilities;
using Umss.BloodOrgansDonationApp.Services;

namespace Umss.BloodOrgansDonationApp.Service.Tests.Services
{
    public class BloodTypeServiceTest : IClassFixture<ServiceFixture>
    {
        private readonly BloodTypeService bloodTypeService;
        private readonly ServiceFixture serviceFixture;
        public BloodTypeServiceTest(ServiceFixture serviceFixture)
        {
            this.serviceFixture = serviceFixture;
            this.bloodTypeService = new BloodTypeService(serviceFixture.BloodTypeRepository);
        }
        private IEnumerable<BloodType> GetBloodTypes()
        {
            BloodType[] bloodTypes = new BloodType[8] {
                new BloodType { Id = Guid.NewGuid(), Name = "O-", Image = String.Empty },
                new BloodType { Id = Guid.NewGuid(), Name = "O+", Image = String.Empty },
                new BloodType { Id = Guid.NewGuid(), Name = "A-", Image = String.Empty },
                new BloodType { Id = Guid.NewGuid(), Name = "A+", Image = String.Empty },
                new BloodType { Id = Guid.NewGuid(), Name = "B-", Image = String.Empty },
                new BloodType { Id = Guid.NewGuid(), Name = "B+", Image = String.Empty },
                new BloodType { Id = Guid.NewGuid(), Name = "AB-", Image = String.Empty },
                new BloodType { Id = Guid.NewGuid(), Name = "AB+", Image = String.Empty },
            };

            return bloodTypes;
        }

        private BloodType GetBloodType()
        {
            BloodType bloodType = new BloodType { Id = Guid.NewGuid(), Name = "O-", Image = String.Empty };

            return bloodType;
        }

        [Fact]
        public async void GetAll()
        {
            this.serviceFixture.BloodTypeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(this.GetBloodTypes());
            var bloodTypes = await this.bloodTypeService.GetAll();

            Assert.NotEmpty(bloodTypes);
        }

        [Fact]
        public async void GetById()
        {
            this.serviceFixture.BloodTypeRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(this.GetBloodType());
            var bloodTypes = await this.bloodTypeService.Get(Guid.NewGuid());

            Assert.NotNull(bloodTypes);
        }
    }
}
