using Domain.Aggregates.AssetAggregate;
using Domain.Primitives;

namespace Domain.Aggregates.InventoryItemAggregate
{
    public class InventoryItemAsset : AggregateRootEntityBase<int>
    {
        public long? InventoryItemFk { get; set; }
        public int? AssetFk { get; set; }
        public Asset? AssetFkNavigation { get; set; }
        public InventoryItem? InventoryItemFkNavigation { get; set; }

        public InventoryItemAsset()
        {
        }

        public InventoryItemAsset(long? inventoryItemFk, int? assetFk, bool isActive) : this()
        {
            InventoryItemFk = inventoryItemFk;
            AssetFk = assetFk;
            IsActive = isActive;
        }

        public static InventoryItemAsset Create(long? inventoryItemFk, int? assetFk, bool isActive)
        {

            return new InventoryItemAsset(inventoryItemFk, assetFk, isActive);
        }

        public void Update(long? inventoryItemFk, int? assetFk, bool isActive)
        {
            InventoryItemFk = inventoryItemFk;
            AssetFk = assetFk;
            IsActive = isActive;
        }
    }
}
