using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;

namespace Domain.Aggregates.InventoryTransfereAggregate
{
    public class InventoryTransfereDetailBatchSerial : AggregateRootEntityBase<int>
    {
        public int? InventoryTransfereDetailBatchFk { get; set; }
        public int? SerialFk { get; set; }
        public InventoryTransfereDetailBatch? InventoryTransfereDetailBatchFkNavigation { get; set; }
        public InventoryItemLocationBatchSerial? SerialFkNavigation { get; set; }

        public InventoryTransfereDetailBatchSerial()
        {
        }

        public InventoryTransfereDetailBatchSerial(int? inventoryTransfereDetailBatchFk, int? serialFk, bool isActive) : this()
        {
            InventoryTransfereDetailBatchFk = inventoryTransfereDetailBatchFk;
            SerialFk = serialFk;
            IsActive = isActive;
        }

        public static InventoryTransfereDetailBatchSerial Create(int? inventoryTransfereDetailBatchFk, int? serialFk, bool isActive)
        {

            return new InventoryTransfereDetailBatchSerial(inventoryTransfereDetailBatchFk, serialFk, isActive);
        }

        public void Update(int? inventoryTransfereDetailBatchFk, int? serialFk, bool isActive)
        {
            InventoryTransfereDetailBatchFk = inventoryTransfereDetailBatchFk;
            SerialFk = serialFk;
            IsActive = isActive;
        }
    }
}
