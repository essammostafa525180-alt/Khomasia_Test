using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;

namespace Domain.Aggregates.InventoryStockCountAggregate
{
    public class AnnualStockCountItemMerge : AggregateRootEntityBase<int>
    {
        public int? AnnualStockCountFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? CurrentQuantity { get; set; }
        public long? ActiveInventoryItemFk { get; set; }
        public InventoryItem? ActiveInventoryItemFkNavigation { get; set; }
        public AnnualStockCount? AnnualStockCountFkNavigation { get; set; }
        public InventoryItem? InventoryItemFkNavigation { get; set; }

        public AnnualStockCountItemMerge()
        {
        }

        public AnnualStockCountItemMerge(int? annualStockCountFk, long? inventoryItemFk, decimal? currentQuantity, long? activeInventoryItemFk, bool isActive) : this()
        {
            AnnualStockCountFk = annualStockCountFk;
            InventoryItemFk = inventoryItemFk;
            CurrentQuantity = currentQuantity;
            ActiveInventoryItemFk = activeInventoryItemFk;
            IsActive = isActive;
        }

        public static AnnualStockCountItemMerge Create(int? annualStockCountFk, long? inventoryItemFk, decimal? currentQuantity, long? activeInventoryItemFk, bool isActive)
        {

            return new AnnualStockCountItemMerge(annualStockCountFk, inventoryItemFk, currentQuantity, activeInventoryItemFk, isActive);
        }

        public void Update(int? annualStockCountFk, long? inventoryItemFk, decimal? currentQuantity, long? activeInventoryItemFk, bool isActive)
        {
            AnnualStockCountFk = annualStockCountFk;
            InventoryItemFk = inventoryItemFk;
            CurrentQuantity = currentQuantity;
            ActiveInventoryItemFk = activeInventoryItemFk;
            IsActive = isActive;
        }
    }
}
