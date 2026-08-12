using Domain.Aggregates.InventoryStockCountAggregate;
using Domain.Aggregates.InventoryTransfereAggregate;
using Domain.Aggregates.RequestAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.InventoryItemAggregate
{
    public class InventoryItemLocationBatch : AggregateRootEntityBase<int>
    {
        public int? InventoryItemLocationFk { get; set; }
        public string? BatchNumber { get; set; }
        public int? ShelfFk { get; set; }
        public decimal? TotalQuantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public long? InventoryItemFk { get; set; }
        public DateTime? ProductionDate { get; set; }
        public InventoryItemLocation? InventoryItemLocationFkNavigation { get; set; }
        public Shelf? ShelfFkNavigation { get; set; }

        private List<InventoryItemLocationBatchSerial> _inventoryItemLocationBatchSerials = new List<InventoryItemLocationBatchSerial>();
        public IReadOnlyCollection<InventoryItemLocationBatchSerial> InventoryItemLocationBatchSerials => _inventoryItemLocationBatchSerials;

        private List<InventoryStockCountDetailBatch> _inventoryStockCountDetailBatches = new List<InventoryStockCountDetailBatch>();
        public IReadOnlyCollection<InventoryStockCountDetailBatch> InventoryStockCountDetailBatches => _inventoryStockCountDetailBatches;

        private List<InventoryTransfereDetailBatch> _inventoryTransfereDetailBatches = new List<InventoryTransfereDetailBatch>();
        public IReadOnlyCollection<InventoryTransfereDetailBatch> InventoryTransfereDetailBatches => _inventoryTransfereDetailBatches;

        private List<RwDeliveredBatch> _rwDeliveredBatches = new List<RwDeliveredBatch>();
        public IReadOnlyCollection<RwDeliveredBatch> RwDeliveredBatches => _rwDeliveredBatches;

        public InventoryItemLocationBatch()
        {
        }

        public InventoryItemLocationBatch(int? inventoryItemLocationFk, string? batchNumber, int? shelfFk, decimal? totalQuantity, DateTime? expiryDate, long? inventoryItemFk, DateTime? productionDate, bool isActive) : this()
        {
            InventoryItemLocationFk = inventoryItemLocationFk;
            BatchNumber = batchNumber;
            ShelfFk = shelfFk;
            TotalQuantity = totalQuantity;
            ExpiryDate = expiryDate;
            InventoryItemFk = inventoryItemFk;
            ProductionDate = productionDate;
            IsActive = isActive;
        }

        public static InventoryItemLocationBatch Create(int? inventoryItemLocationFk, string? batchNumber, int? shelfFk, decimal? totalQuantity, DateTime? expiryDate, long? inventoryItemFk, DateTime? productionDate, bool isActive)
        {

            return new InventoryItemLocationBatch(inventoryItemLocationFk, batchNumber, shelfFk, totalQuantity, expiryDate, inventoryItemFk, productionDate, isActive);
        }

        public void Update(int? inventoryItemLocationFk, string? batchNumber, int? shelfFk, decimal? totalQuantity, DateTime? expiryDate, long? inventoryItemFk, DateTime? productionDate, bool isActive)
        {
            InventoryItemLocationFk = inventoryItemLocationFk;
            BatchNumber = batchNumber;
            ShelfFk = shelfFk;
            TotalQuantity = totalQuantity;
            ExpiryDate = expiryDate;
            InventoryItemFk = inventoryItemFk;
            ProductionDate = productionDate;
            IsActive = isActive;
        }
    }
}
