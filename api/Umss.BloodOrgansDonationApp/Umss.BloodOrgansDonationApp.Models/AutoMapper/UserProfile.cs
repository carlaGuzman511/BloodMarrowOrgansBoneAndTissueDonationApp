using AutoMapper;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;

namespace Umss.BloodOrgansDonationApp.Models.AutoMapper
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<UserRequest, User>()
                .ForMember(c => c.Id, x => x.Ignore())
                .ForMember(c => c.DonationPosts, x => x.Ignore());

            CreateMap<User, UserResponse>();
        }
    }
}
