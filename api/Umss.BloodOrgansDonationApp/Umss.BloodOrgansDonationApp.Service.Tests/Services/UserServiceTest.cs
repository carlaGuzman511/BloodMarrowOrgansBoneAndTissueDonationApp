using Moq;
using System.Net;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;
using Umss.BloodOrgansDonationApp.Service.Tests.Utilities;
using Umss.BloodOrgansDonationApp.Services;
using static System.Net.Mime.MediaTypeNames;

namespace Umss.BloodOrgansDonationApp.Service.Tests.Services
{
    public class UserServiceTest : IClassFixture<ServiceFixture>
    {
        protected readonly UserService userService;
        protected readonly ServiceFixture serviceFixture;

        public UserServiceTest(ServiceFixture serviceFixture)
        {
            this.serviceFixture = serviceFixture;
            this.userService = new UserService(this.serviceFixture.UserRepository);
        }

        private IEnumerable<User> GetUsers() 
        {
            User[] users = new User[8]
            {
                new User {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), Password = "xtygfjd" },
                new User {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), Password = "xtygfjd" },
                new User {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), Password = "xtygfjd" },
                new User {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), Password = "xtygfjd" },
                new User {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), Password = "xtygfjd" },
                new User {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), Password = "xtygfjd" },
                new User {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), Password = "xtygfjd" },
                new User {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), Password = "xtygfjd" },
            };

            return users;
        }
        private UserRequest GetUserRequest()
        {
            UserRequest userRequest = new UserRequest 
            {
                FullName = string.Empty, 
                Email = string.Empty,
                BloodTypeId = Guid.NewGuid(),
                Password = string.Empty,
                Address = string.Empty,
                DateOfBirth = new DateOnly(1998, 11, 5),
                PhoneNumber = string.Empty,
                Image = string.Empty,
            };

            return userRequest;
        }
        private User GetUser()
        {
            User user = new User { Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), Password = "xtygfjd" };

            return user;
        }

        [Fact]
        public async void GetAll()
        {
            this.serviceFixture.UserRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(this.GetUsers());
            IEnumerable<UserResponse> users = await this.userService.GetAll();

            Assert.NotEmpty(users);
        }

        [Fact]
        public async void GetById()
        {
            this.serviceFixture.UserRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(this.GetUser());
            UserResponse user = await this.userService.Get(Guid.NewGuid());

            Assert.NotNull(user);
        }

        [Fact]
        public async void Create()
        {
            this.serviceFixture.UserRepositoryMock.Setup(x => x.Create(It.IsAny<User>())).ReturnsAsync(this.GetUser());
            UserResponse userResponse = await this.userService.Create(this.GetUserRequest());

            Assert.NotNull(userResponse);
        }

        [Fact]
        public async void Delete()
        {
            this.serviceFixture.UserRepositoryMock.Setup(x => x.Delete(It.IsAny<Guid>()));
            await this.userService.Delete(Guid.NewGuid());
        }

        [Fact]
        public async void Update()
        {
            this.serviceFixture.UserRepositoryMock.Setup(x => x.Update(It.IsAny<User>())).ReturnsAsync(this.GetUser());
            UserResponse userResponse = await this.userService.Update(Guid.NewGuid(), this.GetUserRequest());

            Assert.NotNull(userResponse);
        }
    }
}
