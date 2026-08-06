using Domain.Primitives;

namespace Domain.Aggregates.StoreAggregate
{
    public class Store : AggregateRootEntityBase<int>
    {
        public Store()
        {
        }

        public Store(bool isActive) : this()
        {
            IsActive = isActive;
        }

        public static Store Create(bool isActive = false) => new Store(isActive);

        public void Update(bool isActive) => IsActive = isActive;
    }
}
