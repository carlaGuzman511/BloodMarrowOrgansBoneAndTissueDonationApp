namespace Umss.BloodOrgansDonationApp.Models
{
    public class BloodType
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Image { get; set; }
    }
}
