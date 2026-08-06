using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.InventoryStockCountAggregate
{
    public class InventoryStockCountDetail : AggregateRootEntityBase<int>
    {
        public int? InventoryStockCountFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? CountQuantity { get; set; }
        public string? IncDecReason { get; set; }
        public InventoryItem? InventoryItemFkNavigation { get; set; }
        public InventoryStockCount? InventoryStockCountFkNavigation { get; set; }

        private List<InventoryStockCountDetailBatch> _inventoryStockCountDetailBatches = new List<InventoryStockCountDetailBatch>();
        public IReadOnlyCollection<InventoryStockCountDetailBatch> InventoryStockCountDetailBatches => _inventoryStockCountDetailBatches;

        public InventoryStockCountDetail()
        {
        }

        public InventoryStockCountDetail(int? inventoryStockCountFk, long? inventoryItemFk, decimal? quantity, decimal? countQuantity, string? incDecReason, bool isActive) : this()
        {
            InventoryStockCountFk = inventoryStockCountFk;
            InventoryItemFk = inventoryItemFk;
            Quantity = quantity;
            CountQuantity = countQuantity;
            IncDecReason = incDecReason;
            IsActive = isActive;
        }

        public static InventoryStockCountDetail Create(int? inventoryStockCountFk, long? inventoryItemFk, decimal? quantity, decimal? countQuantity, string? incDecReason, bool isActive)
        {

            return new InventoryStockCountDetail(inventoryStockCountFk, inventoryItemFk, quantity, countQuantity, incDecReason, isActive);
        }

        public void Update(int? inventoryStockCountFk, long? inventoryItemFk, decimal? quantity, decimal? countQuantity, string? incDecReason, bool isActive)
        {
            InventoryStockCountFk = inventoryStockCountFk;
            InventoryItemFk = inventoryItemFk;
            Quantity = quantity;
            CountQuantity = countQuantity;
            IncDecReason = incDecReason;
            IsActive = isActive;
        }
    }
}
