using Domain.Primitives;

namespace Domain.Aggregates.InventoryTransfereAggregate
{
    public class InventoryTransfere : AggregateRootEntityBase<int>
    {
        public InventoryTransfere()
        {
        }

        public InventoryTransfere(bool isActive) : this()
        {
            IsActive = isActive;
        }

        public static InventoryTransfere Create(bool isActive = false) => new InventoryTransfere(isActive);

        public void Update(bool isActive) => IsActive = isActive;
    }
}
