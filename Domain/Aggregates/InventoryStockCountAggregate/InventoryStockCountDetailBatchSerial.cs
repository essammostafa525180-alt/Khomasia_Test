using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;

namespace Domain.Aggregates.InventoryStockCountAggregate
{
    public class InventoryStockCountDetailBatchSerial : AggregateRootEntityBase<int>
    {
        public int? InventoryStockCountDetailBatchFk { get; set; }
        public int? InventoryItemLocationBatchSerialFk { get; set; }
        public bool IsNew { get; set; }
        public bool IsSerialExist { get; set; }
        public InventoryItemLocationBatchSerial? InventoryItemLocationBatchSerialFkNavigation { get; set; }
        public InventoryStockCountDetailBatch? InventoryStockCountDetailBatchFkNavigation { get; set; }

        public InventoryStockCountDetailBatchSerial()
        {
        }

        public InventoryStockCountDetailBatchSerial(int? inventoryStockCountDetailBatchFk, int? inventoryItemLocationBatchSerialFk, bool isNew, bool isSerialExist, bool isActive) : this()
        {
            InventoryStockCountDetailBatchFk = inventoryStockCountDetailBatchFk;
            InventoryItemLocationBatchSerialFk = inventoryItemLocationBatchSerialFk;
            IsNew = isNew;
            IsSerialExist = isSerialExist;
            IsActive = isActive;
        }

        public static InventoryStockCountDetailBatchSerial Create(int? inventoryStockCountDetailBatchFk, int? inventoryItemLocationBatchSerialFk, bool isNew, bool isSerialExist, bool isActive)
        {

            return new InventoryStockCountDetailBatchSerial(inventoryStockCountDetailBatchFk, inventoryItemLocationBatchSerialFk, isNew, isSerialExist, isActive);
        }

        public void Update(int? inventoryStockCountDetailBatchFk, int? inventoryItemLocationBatchSerialFk, bool isNew, bool isSerialExist, bool isActive)
        {
            InventoryStockCountDetailBatchFk = inventoryStockCountDetailBatchFk;
            InventoryItemLocationBatchSerialFk = inventoryItemLocationBatchSerialFk;
            IsNew = isNew;
            IsSerialExist = isSerialExist;
            IsActive = isActive;
        }
    }
}
