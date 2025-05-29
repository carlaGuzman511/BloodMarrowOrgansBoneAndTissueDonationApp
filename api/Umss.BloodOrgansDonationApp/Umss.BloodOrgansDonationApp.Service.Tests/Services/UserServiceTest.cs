using Moq;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Entities;
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
            this.userService = new UserService(this.repositoryFixture.UserRepository, this.repositoryFixture.Mapper);
        }
        private IEnumerable<UserResponse> GetUserResponses()
        {
            UserResponse[] users = new UserResponse[8]
            {
                new UserResponse {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), Password = "xtygfjd", Latitude = 17.525, Longitude = 12.2555 },
                new UserResponse {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), Password = "xtygfjd", Latitude = 17.525, Longitude = 12.2555 },
                new UserResponse {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), Password = "xtygfjd", Latitude = 17.525, Longitude = 12.2555 },
                new UserResponse {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), Password = "xtygfjd", Latitude = 17.525, Longitude = 12.2555 },
                new UserResponse {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), Password = "xtygfjd", Latitude = 17.525, Longitude = 12.2555 },
                new UserResponse {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), Password = "xtygfjd", Latitude = 17.525, Longitude = 12.2555 },
                new UserResponse {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), Password = "xtygfjd", Latitude = 17.525, Longitude = 12.2555 },
                new UserResponse {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), Password = "xtygfjd", Latitude = 17.525, Longitude = 12.2555 },
            };

            return users;
        }
        private IEnumerable<User> GetUsers() 
        {
            User[] users = new User[8]
            {
                new User {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), PasswordHash = "xtygfjd", Latitude = 17.525, Longitude = 12.2555 },
                new User {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), PasswordHash = "xtygfjd", Latitude = 17.525, Longitude = 12.2555 },
                new User {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), PasswordHash = "xtygfjd", Latitude = 17.525, Longitude = 12.2555 },
                new User {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), PasswordHash = "xtygfjd", Latitude = 17.525, Longitude = 12.2555 },
                new User {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), PasswordHash = "xtygfjd", Latitude = 17.525, Longitude = 12.2555 },
                new User {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), PasswordHash = "xtygfjd", Latitude = 17.525, Longitude = 12.2555 },
                new User {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), PasswordHash = "xtygfjd", Latitude = 17.525, Longitude = 12.2555 },
                new User {Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), PasswordHash = "xtygfjd", Latitude = 17.525, Longitude = 12.2555 },
            };

            return users;
        }
        private UserRequest GetValidUserRequest()
        {
            UserRequest userRequest = new UserRequest 
            {
                FullName = "Jhon Doe", 
                Email = "new.user@gmail.com",
                BloodTypeId = Guid.NewGuid(),
                Password = "jd7+es87s#sd01.",
                Address = "Av. America",
                DateOfBirth = new DateOnly(1998, 11, 5),
                PhoneNumber = "+59175478526",
                Image = "abc",
                Latitude = 17.525,
                Longitude = 12.2555,
            };

            return userRequest;
        }

        private UserRequest GetInvalidUserRequest()
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
                Latitude = 17.525,
                Longitude = 12.2555,
            };

            return userRequest;
        }
        private User GetUser()
        {
            User user = new User { Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), PasswordHash = "xtygfjd", Latitude = 17.525, Longitude = 12.2555 };

            return user;
        }

        private UserResponse GetUserResponse()
        {
            UserResponse user = new UserResponse { Id = Guid.NewGuid(), FullName = "Juan Perez", Email = "juan.perez@gmail.com", Address = "Av. America Nro. 897", Image = string.Empty, PhoneNumber = "+59175478526", DateOfBirth = new DateOnly(1998, 11, 5), BloodTypeId = Guid.NewGuid(), Password = "xtygfjd", Latitude = 17.525, Longitude = 12.2555 };

            return user;
        }

        [Fact]
        public async Task GetAll()
        {
            this.repositoryFixture.UserRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(this.GetUsers());
            IEnumerable<UserResponse> users = await this.userService.GetAll();

            Assert.NotEmpty(users);
        }

        [Fact]
        public async Task GetById()
        {
            this.repositoryFixture.UserRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(this.GetUser());
            this.repositoryFixture.MapperMock.Setup(x => x.Map<UserResponse>(It.IsAny<User>())).Returns(this.GetUserResponse());

            UserResponse? user = await this.userService.Get(Guid.NewGuid());

            Assert.NotNull(user);
        }

        [Fact]
        public async Task Create_ValidUser()
        {
            this.repositoryFixture.MapperMock.Setup(x => x.Map<User>(It.IsAny<UserRequest>())).Returns(this.GetUser());
            this.repositoryFixture.UserRepositoryMock.Setup(x => x.Create(It.IsAny<User>())).ReturnsAsync(this.GetUser());
            this.repositoryFixture.MapperMock.Setup(x => x.Map<UserResponse>(It.IsAny<User>())).Returns(this.GetUserResponse());

            UserResponse userResponse = await this.userService.Create(this.GetValidUserRequest());

            Assert.NotNull(userResponse);
        }

        [Fact]
        public async Task Create_InvalidUser_ThrowsValidationExceptions()
        {
            FluentValidation.ValidationException exception = await Assert.ThrowsAsync<FluentValidation.ValidationException>(() => userService.Create(this.GetInvalidUserRequest()));

            //Assert.
            Assert.Equal("exception.Message = \"Validation failed: \\r\\n -- Email: El email del usuario es requerido Severity: Error\\r\\n -- Address: La direccion del usuario es requerido Severity: Error\\r\\n -- Password: El password del usuario es requerido Severity: Error\\r\\n -- PhoneNumber: El numero de...", exception.Message);
            this.repositoryFixture.UserRepositoryMock.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
        }

        [Fact]
        public async Task Delete()
        {
            this.repositoryFixture.UserRepositoryMock.Setup(x => x.Delete(It.IsAny<Guid>()));
            await this.userService.Delete(Guid.NewGuid());
        }

        [Fact]
        public async Task Update_ValidUser()
        {
            this.repositoryFixture.MapperMock.Setup(x => x.Map<User>(It.IsAny<UserRequest>())).Returns(this.GetUser());
            this.repositoryFixture.UserRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(this.GetUser());
            this.repositoryFixture.UserRepositoryMock.Setup(x => x.Update(It.IsAny<User>())).ReturnsAsync(this.GetUser());
            this.repositoryFixture.MapperMock.Setup(x => x.Map<UserResponse>(It.IsAny<User>())).Returns(this.GetUserResponse());

            UserResponse userResponse = await this.userService.Update(Guid.NewGuid(), this.GetValidUserRequest());

            Assert.NotNull(userResponse);
        }

        [Fact]
        public async Task Update_InvalidUser()
        {
            this.repositoryFixture.MapperMock.Setup(x => x.Map<User>(It.IsAny<UserRequest>())).Returns(this.GetUser());
            this.repositoryFixture.UserRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(this.GetUser());
            this.repositoryFixture.UserRepositoryMock.Setup(x => x.Update(It.IsAny<User>())).ReturnsAsync(this.GetUser());
            this.repositoryFixture.MapperMock.Setup(x => x.Map<UserResponse>(It.IsAny<User>())).Returns(this.GetUserResponse());

            UserResponse userResponse = await this.userService.Update(Guid.NewGuid(), this.GetValidUserRequest());

            Assert.NotNull(userResponse);
        }
    }
}
