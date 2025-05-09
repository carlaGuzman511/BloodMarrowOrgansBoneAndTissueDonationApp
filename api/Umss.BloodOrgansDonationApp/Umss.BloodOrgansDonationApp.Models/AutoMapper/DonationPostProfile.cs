using AutoMapper;
using Umss.BloodOrgansDonationApp.Models.Requests;

namespace Umss.BloodOrgansDonationApp.Models.AutoMapper
{
    public class DonationPostProfile: Profile
    {
        public DonationPostProfile()
        {
            CreateMap<DonationPostRequest, DonationPost>()
                .ForMember(dp => dp.Id, x => x.Ignore())
                .ForMember(dp => dp.BloodType, x => x.Ignore())
                .ForMember(dp => dp.Comments, x => x.Ignore())
                .ForMember(dp => dp.DonationCenter, x => x.Ignore())
                .ForMember(dp => dp.DonationType, x => x.Ignore())
                .ForMember(dp => dp.UpdatedAt, x => x.Ignore())
                .ForMember(dp => dp.User, x => x.Ignore())
                .ForMember(dp => dp.CreatedAt, x => x.Ignore());
        }
    }
}
