
namespace UserDeviceManager.Data.IRepository
{
    public interface IRepository<T> where T : class, IEntity
    {
        void Add(T entity, CancellationToken token);
        Task<bool> DeleteAsync(int id, CancellationToken token);
      //  Task<IEnumerable<T>> GetAllAsync(CancellationToken token);
        IQueryable<T> GetAllAsync(CancellationToken token);
    //    Task<T> GetByIdAsync(int id, CancellationToken token);
        void Update(T entity);
    }
}