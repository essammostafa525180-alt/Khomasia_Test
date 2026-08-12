using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.InventoryStockCountAggregate
{
    public class InventoryStockCountDetailBatch : AggregateRootEntityBase<int>
    {
        public int? InventoryStockCountDetailFk { get; set; }
        public int? BatchFk { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? CountQuantity { get; set; }
        public InventoryItemLocationBatch? BatchFkNavigation { get; set; }
        public InventoryStockCountDetail? InventoryStockCountDetailFkNavigation { get; set; }

        private List<InventoryStockCountDetailBatchSerial> _inventoryStockCountDetailBatchSerials = new List<InventoryStockCountDetailBatchSerial>();
        public IReadOnlyCollection<InventoryStockCountDetailBatchSerial> InventoryStockCountDetailBatchSerials => _inventoryStockCountDetailBatchSerials;

        public InventoryStockCountDetailBatch()
        {
        }

        public InventoryStockCountDetailBatch(int? inventoryStockCountDetailFk, int? batchFk, decimal? quantity, decimal? countQuantity, bool isActive) : this()
        {
            InventoryStockCountDetailFk = inventoryStockCountDetailFk;
            BatchFk = batchFk;
            Quantity = quantity;
            CountQuantity = countQuantity;
            IsActive = isActive;
        }

        public static InventoryStockCountDetailBatch Create(int? inventoryStockCountDetailFk, int? batchFk, decimal? quantity, decimal? countQuantity, bool isActive)
        {

            return new InventoryStockCountDetailBatch(inventoryStockCountDetailFk, batchFk, quantity, countQuantity, isActive);
        }

        public void Update(int? inventoryStockCountDetailFk, int? batchFk, decimal? quantity, decimal? countQuantity, bool isActive)
        {
            InventoryStockCountDetailFk = inventoryStockCountDetailFk;
            BatchFk = batchFk;
            Quantity = quantity;
            CountQuantity = countQuantity;
            IsActive = isActive;
        }
    }
}
