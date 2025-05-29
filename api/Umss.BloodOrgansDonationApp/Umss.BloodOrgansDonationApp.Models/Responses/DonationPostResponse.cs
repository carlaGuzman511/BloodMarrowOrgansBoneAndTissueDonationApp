namespace Umss.BloodOrgansDonationApp.Models.Responses
{
    public class DonationPostResponse
    {
        public Guid Id { get; set; }
        public BloodType BloodType { get; set; }
        public DonationTypeResponse DonationType { get; set; }
        public UserResponse? User { get; set; }
        public DonationCenterResponse? DonationCenter { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<CommentResponse> Comments { get; set; }
    }
}
