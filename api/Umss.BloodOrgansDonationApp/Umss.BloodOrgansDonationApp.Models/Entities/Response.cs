namespace Umss.BloodOrgansDonationApp.Models.Entities
{
    public class Response<T>
    {
        public T Data { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
