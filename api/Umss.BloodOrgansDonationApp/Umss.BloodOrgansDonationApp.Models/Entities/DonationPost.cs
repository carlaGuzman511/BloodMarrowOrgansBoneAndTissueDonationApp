using Umss.BloodOrgansDonationApp.Models.Entities;

namespace Umss.BloodOrgansDonationApp.Models
{
    public class DonationPost
    {
        public Guid Id { get; set; }

        public BloodType BloodType { get; set; }

        public Guid BloodTypeId { get; set; }

        public DonationType DonationType { get; set; }

        public Guid DonationTypeId { get; set; }

        public User? User { get; set; }

        public Guid? UserId { get; set; }

        public DonationCenter? DonationCenter { get; set; }

        public Guid? DonationCenterId { get; set; }

        public required string Description { get; set; }

        public required string Image { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
