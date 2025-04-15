namespace Umss.BloodOrgansDonationApp.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public required string FullName { get; set; }

        public required string Email { get; set; }

        public BloodType BloodType { get; set; }

        public required Guid BloodTypeId { get; set; }

        public required string Password { get; set; }

        public required string Address { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public required string PhoneNumber { get; set; }

        public required string Image { get; set; }

        public IEnumerable<DonationPost> DonationPosts;
    }
}
