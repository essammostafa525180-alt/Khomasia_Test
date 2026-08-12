using Domain.Primitives;

namespace Domain.Aggregates.InventoryItemAggregate
{
    public class InventoryItemSerial : AggregateRootEntityBase<int>
    {
        public InventoryItemSerial()
        {
        }

        public InventoryItemSerial(bool isActive) : this()
        {
            IsActive = isActive;
        }

        public static InventoryItemSerial Create(bool isActive = false) => new InventoryItemSerial(isActive);

        public void Update(bool isActive) => IsActive = isActive;
    }
}
