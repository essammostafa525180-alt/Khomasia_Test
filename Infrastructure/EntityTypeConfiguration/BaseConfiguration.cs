using Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityTypeConfiguration;

public class BaseConfiguration<TEntity, TId> : IEntityTypeConfiguration<TEntity> 
    where TEntity : Entity<TId> 
    where TId : struct, IEquatable<TId>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasQueryFilter(order => !order.IsDeleted);
    }
}
