namespace Umss.BloodOrgansDonationApp.Models.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public required string Description { get; set; }
        public DonationPost DonationPost { get; set; }
        public required Guid DonationPostId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}