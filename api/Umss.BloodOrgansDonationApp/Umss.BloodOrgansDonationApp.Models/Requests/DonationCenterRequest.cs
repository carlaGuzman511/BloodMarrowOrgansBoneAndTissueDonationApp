namespace Umss.BloodOrgansDonationApp.Models.Requests
{
    public class DonationCenterRequest
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public string Image { get; set; }
        public required string City { get; set; }
        public required double Latitude { get; set; }
        public required double Longitude { get; set; }
        public IEnumerable<Guid> DonationTypeIds { get; set; }
    }
}
