using Umss.BloodOrgansDonationApp.Models.Requests;
using Umss.BloodOrgansDonationApp.Models.Responses;

namespace Umss.BloodOrgansDonationApp.Services.Interfaces
{
    public interface ICommentService : IDonationAppService<CommentRequest, CommentResponse>
    {
    }
}
