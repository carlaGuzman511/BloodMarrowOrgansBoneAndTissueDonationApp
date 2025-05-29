using Umss.BloodOrgansDonationApp.Models.Entities;

namespace Umss.BloodOrgansDonationApp.Models
{
    public class DonationType
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Requirements { get; set; }
        public required string Process { get; set; }
        public required string Importance { get; set; }
        public required string Benefits { get; set; }
        public required string SecondaryEffects { get; set; }
        public required string Image { get; set; }

        //public ICollection<DonationCenter> DonationCenters { get; set; }
        public ICollection<DonationCenterDonationType> DonationCenterDonationTypes { get; set; }
    }
}
