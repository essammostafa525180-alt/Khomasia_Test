using Domain.Primitives;

namespace Domain.Aggregates.InventoryItemAggregate
{
    public class InventoryItemLocation : AggregateRootEntityBase<int>
    {
        public InventoryItemLocation()
        {
        }

        public InventoryItemLocation(bool isActive) : this()
        {
            IsActive = isActive;
        }

        public static InventoryItemLocation Create(bool isActive = false) => new InventoryItemLocation(isActive);

        public void Update(bool isActive) => IsActive = isActive;
    }
}
