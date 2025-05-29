using Umss.BloodOrgansDonationApp.Models;

namespace Umss.BloodOrgansDonationApp.Repository.Interfaces
{
    public interface IDonationTypeRepository: IDonationAppRepository<DonationType>
    {
        public Task<IEnumerable<DonationType>> GetByIds(IEnumerable<Guid> donationTypeIds);
    }
}
