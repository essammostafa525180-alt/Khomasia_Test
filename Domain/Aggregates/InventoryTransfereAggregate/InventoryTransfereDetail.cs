using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.InventoryTransfereAggregate
{
    public class InventoryTransfereDetail : AggregateRootEntityBase<int>
    {
        public int? InventoryTransfereFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? Quantity { get; set; }
        public InventoryItem? InventoryItemFkNavigation { get; set; }
        public InventoryTransfere? InventoryTransfereFkNavigation { get; set; }

        private List<InventoryTransfereDetailBatch> _inventoryTransfereDetailBatches = new List<InventoryTransfereDetailBatch>();
        public IReadOnlyCollection<InventoryTransfereDetailBatch> InventoryTransfereDetailBatches => _inventoryTransfereDetailBatches;

        private List<InventoryTransfereSerial> _inventoryTransfereSerials = new List<InventoryTransfereSerial>();
        public IReadOnlyCollection<InventoryTransfereSerial> InventoryTransfereSerials => _inventoryTransfereSerials;

        public InventoryTransfereDetail()
        {
        }

        public InventoryTransfereDetail(int? inventoryTransfereFk, long? inventoryItemFk, decimal? quantity, bool isActive) : this()
        {
            InventoryTransfereFk = inventoryTransfereFk;
            InventoryItemFk = inventoryItemFk;
            Quantity = quantity;
            IsActive = isActive;
        }

        public static InventoryTransfereDetail Create(int? inventoryTransfereFk, long? inventoryItemFk, decimal? quantity, bool isActive)
        {

            return new InventoryTransfereDetail(inventoryTransfereFk, inventoryItemFk, quantity, isActive);
        }

        public void Update(int? inventoryTransfereFk, long? inventoryItemFk, decimal? quantity, bool isActive)
        {
            InventoryTransfereFk = inventoryTransfereFk;
            InventoryItemFk = inventoryItemFk;
            Quantity = quantity;
            IsActive = isActive;
        }
    }
}
