using Domain.Abstractions;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Repository<TEntity,TId> : IRepository<TEntity,TId> 
        where TEntity : Entity<TId> where TId : struct, IEquatable<TId>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _applicationDbContext.Set<TEntity>().ToListAsync<TEntity>();
        }

        public async Task<TEntity?> GetByIdAsync(TId id)
        {
            return await _applicationDbContext.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _applicationDbContext.Set<TEntity>().AsQueryable();
        }
        public async Task AddAsync(TEntity entity)
        {
            await _applicationDbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddAsyncRange(IEnumerable<TEntity> entities)
        {
            await _applicationDbContext.Set<TEntity>().AddRangeAsync(entities);
        }

        public void HardDelete(TEntity entity)
        {
            _applicationDbContext.Set<TEntity>().Remove(entity);
        }

        public void HardDeleteRange(IEnumerable<TEntity> entities)
        {
            _applicationDbContext.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _applicationDbContext.Set<TEntity>().Update(entity);
        }

        public void SoftDelete(TEntity entity)
        {
            entity.IsDeleted = true;
            //entity.DeletedAt = DateTime.Now;
        }

        public void SoftDeleteRange(IEnumerable<TEntity> entities)
        {
            entities.ToList().ForEach(entity => entity.SoftDelete());
        }

       
    }
}
