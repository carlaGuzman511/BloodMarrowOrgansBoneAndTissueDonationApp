namespace Umss.BloodOrgansDonationApp.Models.Requests
{
    public class DonationPostRequest
    {
        public Guid BloodTypeId { get; set; }

        public Guid DonationTypeId { get; set; }

        public Guid UserId { get; set; }

        public required string Description { get; set; }

        public required string Image { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
