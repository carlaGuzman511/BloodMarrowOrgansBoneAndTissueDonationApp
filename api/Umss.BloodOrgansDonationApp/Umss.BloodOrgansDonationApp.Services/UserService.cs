using AutoMapper;
using FluentValidation;
using Umss.BloodOrgansDonationApp.Models;
using Umss.BloodOrgansDonationApp.Models.Exceptions;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;
using Umss.BloodOrgansDonationApp.Repository;
using Umss.BloodOrgansDonationApp.Repository.Interfaces;
using Umss.BloodOrgansDonationApp.Services.Interfaces;
using Umss.BloodOrgansDonationApp.Services.Validators;

namespace Umss.BloodOrgansDonationApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserResponse> Create(UserRequest userRequest)
        {
            UserRequestValidator userRequestValidator = new UserRequestValidator();
            userRequestValidator.ValidateAndThrow(userRequest);

            User user = _mapper.Map<User>(userRequest);
            user.Id = Guid.NewGuid();

            user = await _userRepository.Create(user);

            return _mapper.Map<UserResponse>(user);
        }

        public async Task Delete(Guid id)
        {
            await _userRepository.Delete(id);
        }

        public async Task<UserResponse?> Get(Guid id)
        {
            User? user = await _userRepository.Get(id);
            if (user != null)
            {
                return _mapper.Map<UserResponse>(user);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<UserResponse>> GetAll()
        {
            IEnumerable<User> users = await _userRepository.GetAll();
            IEnumerable<UserResponse> response = users.Select(x => _mapper.Map<UserResponse>(x));

            return response;
        }

        public async Task<UserResponse> Update(Guid id, UserRequest userRequest)
        {
            User? user = await _userRepository.Get(id);
            if (user == null)
            {
                throw new EntityNotFoundException($"User with ID {id} not found.");
            }

            UserRequestValidator userRequestValidator = new UserRequestValidator();
            userRequestValidator.ValidateAndThrow(userRequest);

            _mapper.Map(userRequest, user);
            user.Id = id;

            user = await _userRepository.Update(user);

            return _mapper.Map<UserResponse>(user);
        }
        //D:\aso-2022\Xen.rar
        //XenServer….exe
    }
}
