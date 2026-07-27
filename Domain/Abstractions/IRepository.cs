namespace Domain.Abstractions;
public interface IRepository<TEntity,TId>
{
    IQueryable<TEntity> GetQueryable();
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(TId id);
    Task AddAsync(TEntity entity);
    Task AddAsyncRange(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void HardDelete(TEntity entity);
    void HardDeleteRange(IEnumerable<TEntity> entities);
    void SoftDelete(TEntity entity);
    void SoftDeleteRange(IEnumerable<TEntity> entities);
    
}
