using AutoMapper;
using Umss.BloodOrgansDonationApp.Models.Entities;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;

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
                .ForMember(dp => dp.DonationCenterId, x => x.Ignore())
                .ForMember(dp => dp.UserId, x => x.Ignore())
                .ForMember(dp => dp.CreatedAt, x => x.Ignore());

            CreateMap<DonationPost, DonationPostResponse>();
            CreateMap<DonationCenter, DonationCenterResponse>();
            CreateMap<DonationType, DonationTypeResponse>();
            CreateMap<User, UserResponse>();
            CreateMap<Comment, CommentResponse>();

            //CreateMap<DonationCenter, DonationCenterResponse>()
            //    .ForMember(dcr => dcr.DonationTypes, x => x.MapFrom(src =>
            //        src.DonationCenterDonationTypes.Select(j => j.DonationType)));

            //CreateMap<DonationType, DonationTypeResponse>();
        }
    }
}
