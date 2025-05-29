using AutoMapper;
using Umss.BloodOrgansDonationApp.Models.Entities;
using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;

namespace Umss.BloodOrgansDonationApp.Models.AutoMapper
{
    public class CommentProfile: Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentRequest, Comment>()
                .ForMember(c => c.Id, x => x.Ignore())
                .ForMember(c => c.CreatedAt, x => x.Ignore())
                .ForMember(c => c.DonationPostId, x => x.Ignore())
                .ForMember(c => c.CreatedAt, x => x.Ignore())
                .ForMember(c => c.UpdatedAt, x => x.Ignore());

            CreateMap<Comment, CommentResponse>();
        }
    }
}
