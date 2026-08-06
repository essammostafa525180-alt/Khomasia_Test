using Domain.Primitives;

namespace Domain.Aggregates.InventoryStockCountAggregate
{
    public class InventoryStockCount : AggregateRootEntityBase<int>
    {
        public InventoryStockCount()
        {
        }

        public InventoryStockCount(bool isActive) : this()
        {
            IsActive = isActive;
        }

        public static InventoryStockCount Create(bool isActive = false) => new InventoryStockCount(isActive);

        public void Update(bool isActive) => IsActive = isActive;
    }
}
