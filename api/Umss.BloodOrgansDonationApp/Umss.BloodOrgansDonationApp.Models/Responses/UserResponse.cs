namespace Umss.BloodOrgansDonationApp.Models.Responses
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required Guid BloodTypeId { get; set; }
        public required string Password { get; set; }
        public string? Address { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Image { get; set; }
        public required double Latitude { get; set; }
        public required double Longitude { get; set; }

        public ICollection<DonationPost> DonationPosts;
    }
}
