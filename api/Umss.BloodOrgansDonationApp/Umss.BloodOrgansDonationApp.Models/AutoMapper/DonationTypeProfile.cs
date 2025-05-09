using AutoMapper;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;

namespace Umss.BloodOrgansDonationApp.Models.AutoMapper
{
    public class DonationTypeProfile: Profile
    {
        public DonationTypeProfile()
        {
            CreateMap<DonationTypeRequest, DonationType>()
                .ForMember(dt => dt.Id, x => x.Ignore())
                .ForMember(dt => dt.DonationCenterDonationTypes, x => x.Ignore());

            CreateMap<DonationType, DonationTypeResponse>();
        }
    }
}
