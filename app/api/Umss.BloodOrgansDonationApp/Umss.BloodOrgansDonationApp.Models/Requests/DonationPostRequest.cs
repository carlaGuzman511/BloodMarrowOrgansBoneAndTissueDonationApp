namespace Umss.BloodOrgansDonationApp.Models.Requests
{
    public class DonationPostRequest
    {
        public Guid BloodTypeId { get; set; }

        public Guid DonationTypeId { get; set; }

        public Guid? UserId { get; set; }

        public Guid? DonationCenterId { get; set; }

        public required string Description { get; set; }

        public string? Image { get; set; }
    }
}
