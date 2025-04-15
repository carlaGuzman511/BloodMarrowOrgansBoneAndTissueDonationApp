namespace Umss.BloodOrgansDonationApp.Models.Requests
{
    public class UserRequest
    {
        public required string FullName { get; set; }

        public required string Email { get; set; }

        public Guid BloodTypeId { get; set; }

        public required string Password { get; set; }

        public required string Address { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public required string PhoneNumber { get; set; }

        public required string Image { get; set; }
    }
}
