namespace Umss.BloodOrgansDonationApp.Models.Requests
{
    public class CommentRequest
    {
        public required string Description { get; set; }
        public required Guid DonationPostId { get; set; }
    }
}
