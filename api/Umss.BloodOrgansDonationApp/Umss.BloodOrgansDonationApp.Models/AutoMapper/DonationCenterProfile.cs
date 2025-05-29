using AutoMapper;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;

namespace Umss.BloodOrgansDonationApp.Models.AutoMapper
{
    public class DonationCenterProfile: Profile
    {
        public DonationCenterProfile()
        {
            CreateMap<DonationCenterRequest, DonationCenter>()
                .ForMember(dc => dc.Id, x => x.Ignore())
                .ForMember(dc => dc.DonationPosts, x => x.Ignore())
                .ForMember(dc => dc.DonationCenterDonationTypes, x => x.Ignore());

            CreateMap<DonationCenter, DonationCenterResponse>()
                .ForMember(dcr => dcr.DonationTypes, x => x.MapFrom(src =>
                    src.DonationCenterDonationTypes.Select(j => j.DonationType).ToList()));

            CreateMap<DonationType, DonationTypeResponse>();
        }
    }
}
