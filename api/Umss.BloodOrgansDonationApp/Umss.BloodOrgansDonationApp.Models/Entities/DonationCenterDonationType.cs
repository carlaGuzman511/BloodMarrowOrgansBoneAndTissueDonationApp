namespace Umss.BloodOrgansDonationApp.Models.Entities
{
    public class DonationCenterDonationType
    {
        public Guid DonationCenterId { get; set; }
        public DonationCenter DonationCenter { get; set; }
        public Guid DonationTypeId { get; set; }
        public DonationType DonationType { get; set; }
        public bool IsActive { get; set; }
    }
}
