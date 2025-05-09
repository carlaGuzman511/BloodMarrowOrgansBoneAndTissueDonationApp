using AutoMapper;
using Umss.BloodOrgansDonationApp.Models.Requests;

namespace Umss.BloodOrgansDonationApp.Models.AutoMapper
{
    public class BloodTypeProfile: Profile
    {
        public BloodTypeProfile()
        {
            CreateMap<BloodTypeRequest, BloodType>()
                .ForMember(c => c.Id, x => x.Ignore());
        }
    }
}
