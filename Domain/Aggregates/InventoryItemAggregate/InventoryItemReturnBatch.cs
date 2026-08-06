using Domain.Aggregates.RequestAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.InventoryItemAggregate
{
    public class InventoryItemReturnBatch : AggregateRootEntityBase<int>
    {
        public int? ItemReturnDetailFk { get; set; }
        public decimal? ReturnedQuantity { get; set; }
        public int? ReturnReasonFk { get; set; }
        public int? RwDeliveredBatchFk { get; set; }
        public string? Notes { get; set; }
        public int? BatchFk { get; set; }
        public InventoryItemReturnDetail? ItemReturnDetailFkNavigation { get; set; }
        public ReturnReason? ReturnReasonFkNavigation { get; set; }
        public RwDeliveredBatch? RwDeliveredBatchFkNavigation { get; set; }

        private List<InventoryItemReturnBatchSerial> _inventoryItemReturnBatchSerials = new List<InventoryItemReturnBatchSerial>();
        public IReadOnlyCollection<InventoryItemReturnBatchSerial> InventoryItemReturnBatchSerials => _inventoryItemReturnBatchSerials;

        public InventoryItemReturnBatch()
        {
        }

        public InventoryItemReturnBatch(int? itemReturnDetailFk, decimal? returnedQuantity, int? returnReasonFk, int? rwDeliveredBatchFk, string? notes, int? batchFk, bool isActive) : this()
        {
            ItemReturnDetailFk = itemReturnDetailFk;
            ReturnedQuantity = returnedQuantity;
            ReturnReasonFk = returnReasonFk;
            RwDeliveredBatchFk = rwDeliveredBatchFk;
            Notes = notes;
            BatchFk = batchFk;
            IsActive = isActive;
        }

        public static InventoryItemReturnBatch Create(int? itemReturnDetailFk, decimal? returnedQuantity, int? returnReasonFk, int? rwDeliveredBatchFk, string? notes, int? batchFk, bool isActive)
        {

            return new InventoryItemReturnBatch(itemReturnDetailFk, returnedQuantity, returnReasonFk, rwDeliveredBatchFk, notes, batchFk, isActive);
        }

        public void Update(int? itemReturnDetailFk, decimal? returnedQuantity, int? returnReasonFk, int? rwDeliveredBatchFk, string? notes, int? batchFk, bool isActive)
        {
            ItemReturnDetailFk = itemReturnDetailFk;
            ReturnedQuantity = returnedQuantity;
            ReturnReasonFk = returnReasonFk;
            RwDeliveredBatchFk = rwDeliveredBatchFk;
            Notes = notes;
            BatchFk = batchFk;
            IsActive = isActive;
        }
    }
}
