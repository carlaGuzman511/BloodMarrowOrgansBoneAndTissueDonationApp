namespace Umss.BloodOrgansDonationApp.Models.Requests
{
    public class DonationCenterRequest
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public string Image { get; set; }
        public required string City { get; set; }
        public required IEnumerable<DonationType> DonationTypes { get; set; }
    }
}
