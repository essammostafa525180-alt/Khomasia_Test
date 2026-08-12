using Domain.Aggregates.RequestAggregate;
using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.InventoryItemAggregate
{
    public class InventoryItemReturnBatchSerial : AggregateRootEntityBase<int>
    {
        public int? InventoryItemReturnBatchFk { get; set; }
        public int? ReturnReasonFk { get; set; }
        public int? RwDelivedSerialFk { get; set; }
        public string? Notes { get; set; }
        public InventoryItemReturnBatch? InventoryItemReturnBatchFkNavigation { get; set; }
        public ReturnReason? ReturnReasonFkNavigation { get; set; }
        public RwDeliveredSerial? RwDelivedSerialFkNavigation { get; set; }

        public InventoryItemReturnBatchSerial()
        {
        }

        public InventoryItemReturnBatchSerial(int? inventoryItemReturnBatchFk, int? returnReasonFk, int? rwDelivedSerialFk, string? notes, bool isActive) : this()
        {
            InventoryItemReturnBatchFk = inventoryItemReturnBatchFk;
            ReturnReasonFk = returnReasonFk;
            RwDelivedSerialFk = rwDelivedSerialFk;
            Notes = notes;
            IsActive = isActive;
        }

        public static InventoryItemReturnBatchSerial Create(int? inventoryItemReturnBatchFk, int? returnReasonFk, int? rwDelivedSerialFk, string? notes, bool isActive)
        {

            return new InventoryItemReturnBatchSerial(inventoryItemReturnBatchFk, returnReasonFk, rwDelivedSerialFk, notes, isActive);
        }

        public void Update(int? inventoryItemReturnBatchFk, int? returnReasonFk, int? rwDelivedSerialFk, string? notes, bool isActive)
        {
            InventoryItemReturnBatchFk = inventoryItemReturnBatchFk;
            ReturnReasonFk = returnReasonFk;
            RwDelivedSerialFk = rwDelivedSerialFk;
            Notes = notes;
            IsActive = isActive;
        }
    }
}
