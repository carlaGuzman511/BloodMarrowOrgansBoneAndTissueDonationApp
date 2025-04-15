namespace Umss.BloodOrgansDonationApp.Services.Interfaces
{
    public interface IDonationAppService<R, P>
    {
        public Task<IEnumerable<P>> GetAll();
        public Task<P> Get(Guid id);
        public Task<P> Create(R element);
        public Task<P> Update(Guid id, R element);
        public Task Delete(Guid id);
    }
}
