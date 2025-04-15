namespace Umss.BloodOrgansDonationApp.Models
{
    public class DonationCenter
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public string Image { get; set; }
        public required string City { get; set; }
        public IEnumerable<DonationType> DonationTypes { get; set; }
        public IEnumerable<DonationPost> DonationPosts { get; set; }
    }
}
