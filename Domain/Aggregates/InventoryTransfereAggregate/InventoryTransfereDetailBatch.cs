using Domain.Aggregates.InventoryItemAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.InventoryTransfereAggregate
{
    public class InventoryTransfereDetailBatch : AggregateRootEntityBase<int>
    {
        public int? InventoryTransfereDetailFk { get; set; }
        public int? BatchFk { get; set; }
        public string? NewBatchNumber { get; set; }
        public decimal? Qunatity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? ShelfFk { get; set; }
        public InventoryItemLocationBatch? BatchFkNavigation { get; set; }
        public InventoryTransfereDetail? InventoryTransfereDetailFkNavigation { get; set; }
        public Shelf? ShelfFkNavigation { get; set; }

        private List<InventoryTransfereDetailBatchSerial> _inventoryTransfereDetailBatchSerials = new List<InventoryTransfereDetailBatchSerial>();
        public IReadOnlyCollection<InventoryTransfereDetailBatchSerial> InventoryTransfereDetailBatchSerials => _inventoryTransfereDetailBatchSerials;

        public InventoryTransfereDetailBatch()
        {
        }

        public InventoryTransfereDetailBatch(int? inventoryTransfereDetailFk, int? batchFk, string? newBatchNumber, decimal? qunatity, DateTime? expiryDate, int? shelfFk, bool isActive) : this()
        {
            InventoryTransfereDetailFk = inventoryTransfereDetailFk;
            BatchFk = batchFk;
            NewBatchNumber = newBatchNumber;
            Qunatity = qunatity;
            ExpiryDate = expiryDate;
            ShelfFk = shelfFk;
            IsActive = isActive;
        }

        public static InventoryTransfereDetailBatch Create(int? inventoryTransfereDetailFk, int? batchFk, string? newBatchNumber, decimal? qunatity, DateTime? expiryDate, int? shelfFk, bool isActive)
        {

            return new InventoryTransfereDetailBatch(inventoryTransfereDetailFk, batchFk, newBatchNumber, qunatity, expiryDate, shelfFk, isActive);
        }

        public void Update(int? inventoryTransfereDetailFk, int? batchFk, string? newBatchNumber, decimal? qunatity, DateTime? expiryDate, int? shelfFk, bool isActive)
        {
            InventoryTransfereDetailFk = inventoryTransfereDetailFk;
            BatchFk = batchFk;
            NewBatchNumber = newBatchNumber;
            Qunatity = qunatity;
            ExpiryDate = expiryDate;
            ShelfFk = shelfFk;
            IsActive = isActive;
        }
    }
}
