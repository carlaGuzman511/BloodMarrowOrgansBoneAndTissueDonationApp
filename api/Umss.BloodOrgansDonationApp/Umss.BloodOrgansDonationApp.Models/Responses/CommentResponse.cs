namespace Umss.BloodOrgansDonationApp.Models.Responses
{
    public class CommentResponse
    {
        public Guid Id { get; set; }
        public required string Description { get; set; }
        public required Guid DonationPostId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
