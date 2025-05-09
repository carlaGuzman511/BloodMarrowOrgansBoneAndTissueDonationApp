using Umss.BloodOrgansDonationApp.Models.Entities;

namespace Umss.BloodOrgansDonationApp.Models
{
    public class DonationCenter
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public string Image { get; set; }
        public required string City { get; set; }
        public required double Latitude { get; set; }
        public required double Longitude { get; set; }
        
        //public ICollection<DonationType> DonationTypes { get; set; }
        public ICollection<DonationPost> DonationPosts { get; set; }
        public ICollection<DonationCenterDonationType> DonationCenterDonationTypes { get; set; }
    }
}
