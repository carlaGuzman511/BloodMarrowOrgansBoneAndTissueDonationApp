using Moq;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;
using Umss.BloodOrgansDonationApp.Service.Tests.Utilities;
using Umss.BloodOrgansDonationApp.Services;

namespace Umss.BloodOrgansDonationApp.Service.Tests.Services
{
    public class UserServiceTest : IClassFixture<RepositoryFixture>
    {
        protected readonly UserService userService;
        protected readonly RepositoryFixture repositoryFixture;

        public UserServiceTest(RepositoryFixture repositoryFixture)
        {
            this.repositoryFixture = repositoryFixture;
            this.userService = new UserService(this.repositoryFixture.UserRepository);
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
            this.repositoryFixture.UserRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(this.GetUsers());
            IEnumerable<UserResponse> users = await this.userService.GetAll();

            Assert.NotEmpty(users);
        }

        [Fact]
        public async void GetById()
        {
            this.repositoryFixture.UserRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(this.GetUser());
            UserResponse user = await this.userService.Get(Guid.NewGuid());

            Assert.NotNull(user);
        }

        [Fact]
        public async void Create()
        {
            this.repositoryFixture.UserRepositoryMock.Setup(x => x.Create(It.IsAny<User>())).ReturnsAsync(this.GetUser());
            UserResponse userResponse = await this.userService.Create(this.GetUserRequest());

            Assert.NotNull(userResponse);
        }

        [Fact]
        public async void Delete()
        {
            this.repositoryFixture.UserRepositoryMock.Setup(x => x.Delete(It.IsAny<Guid>()));
            await this.userService.Delete(Guid.NewGuid());
        }

        [Fact]
        public async void Update()
        {
            this.repositoryFixture.UserRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(this.GetUser());
            this.repositoryFixture.UserRepositoryMock.Setup(x => x.Update(It.IsAny<User>())).ReturnsAsync(this.GetUser());
            UserResponse userResponse = await this.userService.Update(Guid.NewGuid(), this.GetUserRequest());

            Assert.NotNull(userResponse);
        }
    }
}
