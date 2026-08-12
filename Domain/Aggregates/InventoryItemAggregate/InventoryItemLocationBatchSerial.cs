using Domain.Aggregates.InventoryStockCountAggregate;
using Domain.Aggregates.InventoryTransfereAggregate;
using Domain.Aggregates.RequestAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.InventoryItemAggregate
{
    public class InventoryItemLocationBatchSerial : AggregateRootEntityBase<int>
    {
        public int? InventoryItemLocationBatchFk { get; set; }
        public string? SerialNumber { get; set; }
        public bool? IsAvailable { get; set; }
        public InventoryItemLocationBatch? InventoryItemLocationBatchFkNavigation { get; set; }

        private List<InventoryStockCountDetailBatchSerial> _inventoryStockCountDetailBatchSerials = new List<InventoryStockCountDetailBatchSerial>();
        public IReadOnlyCollection<InventoryStockCountDetailBatchSerial> InventoryStockCountDetailBatchSerials => _inventoryStockCountDetailBatchSerials;

        private List<InventoryTransfereDetailBatchSerial> _inventoryTransfereDetailBatchSerials = new List<InventoryTransfereDetailBatchSerial>();
        public IReadOnlyCollection<InventoryTransfereDetailBatchSerial> InventoryTransfereDetailBatchSerials => _inventoryTransfereDetailBatchSerials;

        private List<RwDeliveredSerial> _rwDeliveredSerials = new List<RwDeliveredSerial>();
        public IReadOnlyCollection<RwDeliveredSerial> RwDeliveredSerials => _rwDeliveredSerials;

        public InventoryItemLocationBatchSerial()
        {
        }

        public InventoryItemLocationBatchSerial(int? inventoryItemLocationBatchFk, string? serialNumber, bool? isAvailable, bool isActive) : this()
        {
            InventoryItemLocationBatchFk = inventoryItemLocationBatchFk;
            SerialNumber = serialNumber;
            IsAvailable = isAvailable;
            IsActive = isActive;
        }

        public static InventoryItemLocationBatchSerial Create(int? inventoryItemLocationBatchFk, string? serialNumber, bool? isAvailable, bool isActive)
        {

            return new InventoryItemLocationBatchSerial(inventoryItemLocationBatchFk, serialNumber, isAvailable, isActive);
        }

        public void Update(int? inventoryItemLocationBatchFk, string? serialNumber, bool? isAvailable, bool isActive)
        {
            InventoryItemLocationBatchFk = inventoryItemLocationBatchFk;
            SerialNumber = serialNumber;
            IsAvailable = isAvailable;
            IsActive = isActive;
        }
    }
}
