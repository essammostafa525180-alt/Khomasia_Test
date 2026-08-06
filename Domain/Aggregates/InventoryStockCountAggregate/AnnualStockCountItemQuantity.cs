using Domain.Primitives;

namespace Domain.Aggregates.InventoryStockCountAggregate
{
    public class AnnualStockCountItemQuantity : AggregateRootEntityBase<int>
    {
        public int? AnnualStockCountFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public string? NewName { get; set; }
        public decimal? CurrentQuantity { get; set; }
        public decimal? StockQuantity { get; set; }
        public Guid? RefId { get; set; }

        public AnnualStockCountItemQuantity()
        {
        }

        public AnnualStockCountItemQuantity(int? annualStockCountFk, long? inventoryItemFk, string? newName, decimal? currentQuantity, decimal? stockQuantity, Guid? refId, bool isActive) : this()
        {
            AnnualStockCountFk = annualStockCountFk;
            InventoryItemFk = inventoryItemFk;
            NewName = newName;
            CurrentQuantity = currentQuantity;
            StockQuantity = stockQuantity;
            RefId = refId;
            IsActive = isActive;
        }

        public static AnnualStockCountItemQuantity Create(int? annualStockCountFk, long? inventoryItemFk, string? newName, decimal? currentQuantity, decimal? stockQuantity, Guid? refId, bool isActive)
        {

            return new AnnualStockCountItemQuantity(annualStockCountFk, inventoryItemFk, newName, currentQuantity, stockQuantity, refId, isActive);
        }

        public void Update(int? annualStockCountFk, long? inventoryItemFk, string? newName, decimal? currentQuantity, decimal? stockQuantity, Guid? refId, bool isActive)
        {
            AnnualStockCountFk = annualStockCountFk;
            InventoryItemFk = inventoryItemFk;
            NewName = newName;
            CurrentQuantity = currentQuantity;
            StockQuantity = stockQuantity;
            RefId = refId;
            IsActive = isActive;
        }
    }
}
