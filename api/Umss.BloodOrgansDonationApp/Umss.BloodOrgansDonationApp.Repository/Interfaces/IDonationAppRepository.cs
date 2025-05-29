namespace Umss.BloodOrgansDonationApp.Repository.Interfaces
{
    public interface IDonationAppRepository<T>
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T?> Get(Guid id);
        public Task<T> Create(T element);
        public Task<T> Update(T element);
        public Task Delete(Guid id);
    }
}
