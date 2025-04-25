using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;
using Umss.BloodOrgansDonationApp.Repository.Interfaces;
using Umss.BloodOrgansDonationApp.Services.Interfaces;

namespace Umss.BloodOrgansDonationApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public async Task<UserResponse> Create(UserRequest userRequest)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Image = userRequest.Image,
                PhoneNumber = userRequest.PhoneNumber,
                BloodTypeId = userRequest.BloodTypeId,
                Password = userRequest.Password,
                Email = userRequest.Email,
                FullName = userRequest.FullName,
                Address = userRequest.Address,
                DateOfBirth = userRequest.DateOfBirth,
            };

            await _userRepository.Create(user);

            var response = new UserResponse
            {
                Id = user.Id,
                Image = user.Image,
                PhoneNumber = user.PhoneNumber,
                BloodTypeId = user.BloodTypeId,
                Password = user.Password,
                Email = user.Email,
                FullName = user.FullName,
                Address = user.Address,
                DateOfBirth = user.DateOfBirth,
            };

            return response;
        }

        public async Task Delete(Guid id)
        {
            var user = await _userRepository.Get(id);
            if (user != null)
            {
                await _userRepository.Delete(id);
            }
            else
            {
                throw new Exception("");
            }
        }

        public async Task<UserResponse> Get(Guid id)
        {
            var user = await _userRepository.Get(id);
            if (user != null)
            {
                var response = new UserResponse
                {
                    Id = user.Id,
                    Image = user.Image,
                    PhoneNumber = user.PhoneNumber,
                    BloodTypeId = user.BloodTypeId,
                    Password = user.Password,
                    Email = user.Email,
                    FullName = user.FullName,
                    Address = user.Address,
                    DateOfBirth = user.DateOfBirth,
                };

                return response;
            }
            else
            {
                throw new Exception("");
            }
        }

        public async Task<IEnumerable<UserResponse>> GetAll()
        {
            var users = await _userRepository.GetAll();
            var response = users.Select(x => new UserResponse
            {
                Id = x.Id,
                Image = x.Image,
                PhoneNumber = x.PhoneNumber,
                BloodTypeId = x.BloodTypeId,
                Password = x.Password,
                Email = x.Email,
                FullName = x.FullName,
                Address = x.Address,
                DateOfBirth = x.DateOfBirth,
            });

            return response;
        }

        public async Task<UserResponse> Update(Guid id, UserRequest userRequest)
        {
            var user = await _userRepository.Get(id);
            if (user != null)
            {
                user.FullName = userRequest.FullName;
                user.Email = userRequest.Email;
                user.Address = userRequest.Address;
                user.PhoneNumber = userRequest.PhoneNumber;
                user.DateOfBirth = userRequest.DateOfBirth;
                user.Password = userRequest.Password;
                user.BloodTypeId = userRequest.BloodTypeId;
                user.Image = userRequest.Image;

                await _userRepository.Update(user);

                return await Get(user.Id);
            }
            else
            {
                throw new Exception("");
            }
        }
    }
}
