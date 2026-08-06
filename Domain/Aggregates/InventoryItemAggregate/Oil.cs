using Domain.Primitives;

namespace Domain.Aggregates.InventoryItemAggregate
{
    public class Oil : AggregateRootEntityBase<int>
    {
        public double? StoreId { get; set; }
        public string? StoreName { get; set; }
        public DateTime? StockCountDate { get; set; }
        public double? InventoryItemId { get; set; }
        public string? InventoryItemCode { get; set; }
        public string? InventoryItemName { get; set; }
        public double? AvgCost { get; set; }
        public double? TotalQuantity { get; set; }
        public double? StockCountQuantity { get; set; }
        public double? Mmbalance { get; set; }
        public string? IsMatch { get; set; }
        public double? IsUpdated { get; set; }

        public Oil()
        {
        }

        public Oil(double? storeId, string? storeName, DateTime? stockCountDate, double? inventoryItemId, string? inventoryItemCode, string? inventoryItemName, double? avgCost, double? totalQuantity, double? stockCountQuantity, double? mmbalance, string? isMatch, double? isUpdated, bool isActive) : this()
        {
            StoreId = storeId;
            StoreName = storeName;
            StockCountDate = stockCountDate;
            InventoryItemId = inventoryItemId;
            InventoryItemCode = inventoryItemCode;
            InventoryItemName = inventoryItemName;
            AvgCost = avgCost;
            TotalQuantity = totalQuantity;
            StockCountQuantity = stockCountQuantity;
            Mmbalance = mmbalance;
            IsMatch = isMatch;
            IsUpdated = isUpdated;
            IsActive = isActive;
        }

        public static Oil Create(double? storeId, string? storeName, DateTime? stockCountDate, double? inventoryItemId, string? inventoryItemCode, string? inventoryItemName, double? avgCost, double? totalQuantity, double? stockCountQuantity, double? mmbalance, string? isMatch, double? isUpdated, bool isActive)
        {

            return new Oil(storeId, storeName, stockCountDate, inventoryItemId, inventoryItemCode, inventoryItemName, avgCost, totalQuantity, stockCountQuantity, mmbalance, isMatch, isUpdated, isActive);
        }

        public void Update(double? storeId, string? storeName, DateTime? stockCountDate, double? inventoryItemId, string? inventoryItemCode, string? inventoryItemName, double? avgCost, double? totalQuantity, double? stockCountQuantity, double? mmbalance, string? isMatch, double? isUpdated, bool isActive)
        {
            StoreId = storeId;
            StoreName = storeName;
            StockCountDate = stockCountDate;
            InventoryItemId = inventoryItemId;
            InventoryItemCode = inventoryItemCode;
            InventoryItemName = inventoryItemName;
            AvgCost = avgCost;
            TotalQuantity = totalQuantity;
            StockCountQuantity = stockCountQuantity;
            Mmbalance = mmbalance;
            IsMatch = isMatch;
            IsUpdated = isUpdated;
            IsActive = isActive;
        }
    }
}
