using Domain.Primitives;

namespace Domain.Aggregates.InventoryItemAggregate
{
    public class InventoryItemEquivalentSp : AggregateRootEntityBase<int>
    {
        public long? InventoryItemFk { get; set; }
        public int? EquivalentItemFk { get; set; }
        public InventoryItem? EquivalentItemFkNavigation { get; set; }
        public InventoryItem? InventoryItemFkNavigation { get; set; }

        public InventoryItemEquivalentSp()
        {
        }

        public InventoryItemEquivalentSp(long? inventoryItemFk, int? equivalentItemFk, bool isActive) : this()
        {
            InventoryItemFk = inventoryItemFk;
            EquivalentItemFk = equivalentItemFk;
            IsActive = isActive;
        }

        public static InventoryItemEquivalentSp Create(long? inventoryItemFk, int? equivalentItemFk, bool isActive)
        {

            return new InventoryItemEquivalentSp(inventoryItemFk, equivalentItemFk, isActive);
        }

        public void Update(long? inventoryItemFk, int? equivalentItemFk, bool isActive)
        {
            InventoryItemFk = inventoryItemFk;
            EquivalentItemFk = equivalentItemFk;
            IsActive = isActive;
        }
    }
}
