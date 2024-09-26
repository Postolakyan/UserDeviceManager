namespace UserDeviceManager.Data.Repository;

public class Repository<T>(DeviceManagerDbContext context) : IRepository<T> where T : class, IEntity
{
    protected readonly DbSet<T> dbSet = context.Set<T>();
    private readonly DeviceManagerDbContext context = context;

    #region CRUD
    public void Add(T entity, CancellationToken token)
    {
        dbSet.AddAsync(entity, token);
    }
    //public async Task<T> GetByIdAsync(int id, CancellationToken token)
    //{
    //    return await dbSet.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id, token);
    //}
    //public async Task<IEnumerable<T>> GetAllAsync(CancellationToken token)
    //{
    //    return await dbSet.AsNoTracking().ToListAsync(token);
    //}
   
    public IQueryable<T> GetAllAsync(CancellationToken token)
    {
        return dbSet.AsNoTracking();
    }

    public void Update(T entity)
    {
        dbSet.Update(entity);
    }
    public async Task<bool> DeleteAsync(int id, CancellationToken token)
    {
        T entity = await GetAllAsync(token).FirstOrDefaultAsync(entity => entity.Id == id, token);

        if (entity is not null)
        {
            dbSet.Remove(entity);
            return true;
        }
        return false;
    }

    #endregion CRUD
}
