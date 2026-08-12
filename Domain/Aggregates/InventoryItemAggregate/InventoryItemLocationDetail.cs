using Domain.Aggregates.StoreAggregate;
using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.InventoryItemAggregate
{
    public class InventoryItemLocationDetail : AggregateRootEntityBase<int>
    {
        public int? StoreFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public int? ItemQuantityTypeFk { get; set; }
        public int? TransactionTypeFk { get; set; }
        public string? Screen { get; set; }
        public int? EntityId { get; set; }
        public string? EntityCode { get; set; }
        public DateTime? EntityDate { get; set; }
        public int? EntityDetailId { get; set; }
        public int? InventoryItemLocationFk { get; set; }
        public decimal? QuantityBefore { get; set; }
        public decimal Quantity { get; set; }
        public decimal? QuantityAfter { get; set; }
        public decimal? EntityDetailCost { get; set; }
        public decimal? Avgcost { get; set; }
        public int? InventoryItemLocationBatchFk { get; set; }
        public InventoryItem? InventoryItemFkNavigation { get; set; }
        public InventoryItemLocation? InventoryItemLocationFkNavigation { get; set; }
        public ItemQuantityType? ItemQuantityTypeFkNavigation { get; set; }
        public Store? StoreFkNavigation { get; set; }
        public InventoryItemTransactionType? TransactionTypeFkNavigation { get; set; }

        public InventoryItemLocationDetail()
        {
        }

        public InventoryItemLocationDetail(int? storeFk, long? inventoryItemFk, int? itemQuantityTypeFk, int? transactionTypeFk, string? screen, int? entityId, string? entityCode, DateTime? entityDate, int? entityDetailId, int? inventoryItemLocationFk, decimal? quantityBefore, decimal quantity, decimal? quantityAfter, decimal? entityDetailCost, decimal? avgcost, int? inventoryItemLocationBatchFk, bool isActive) : this()
        {
            StoreFk = storeFk;
            InventoryItemFk = inventoryItemFk;
            ItemQuantityTypeFk = itemQuantityTypeFk;
            TransactionTypeFk = transactionTypeFk;
            Screen = screen;
            EntityId = entityId;
            EntityCode = entityCode;
            EntityDate = entityDate;
            EntityDetailId = entityDetailId;
            InventoryItemLocationFk = inventoryItemLocationFk;
            QuantityBefore = quantityBefore;
            Quantity = quantity;
            QuantityAfter = quantityAfter;
            EntityDetailCost = entityDetailCost;
            Avgcost = avgcost;
            InventoryItemLocationBatchFk = inventoryItemLocationBatchFk;
            IsActive = isActive;
        }

        public static InventoryItemLocationDetail Create(int? storeFk, long? inventoryItemFk, int? itemQuantityTypeFk, int? transactionTypeFk, string? screen, int? entityId, string? entityCode, DateTime? entityDate, int? entityDetailId, int? inventoryItemLocationFk, decimal? quantityBefore, decimal quantity, decimal? quantityAfter, decimal? entityDetailCost, decimal? avgcost, int? inventoryItemLocationBatchFk, bool isActive)
        {

            return new InventoryItemLocationDetail(storeFk, inventoryItemFk, itemQuantityTypeFk, transactionTypeFk, screen, entityId, entityCode, entityDate, entityDetailId, inventoryItemLocationFk, quantityBefore, quantity, quantityAfter, entityDetailCost, avgcost, inventoryItemLocationBatchFk, isActive);
        }

        public void Update(int? storeFk, long? inventoryItemFk, int? itemQuantityTypeFk, int? transactionTypeFk, string? screen, int? entityId, string? entityCode, DateTime? entityDate, int? entityDetailId, int? inventoryItemLocationFk, decimal? quantityBefore, decimal quantity, decimal? quantityAfter, decimal? entityDetailCost, decimal? avgcost, int? inventoryItemLocationBatchFk, bool isActive)
        {
            StoreFk = storeFk;
            InventoryItemFk = inventoryItemFk;
            ItemQuantityTypeFk = itemQuantityTypeFk;
            TransactionTypeFk = transactionTypeFk;
            Screen = screen;
            EntityId = entityId;
            EntityCode = entityCode;
            EntityDate = entityDate;
            EntityDetailId = entityDetailId;
            InventoryItemLocationFk = inventoryItemLocationFk;
            QuantityBefore = quantityBefore;
            Quantity = quantity;
            QuantityAfter = quantityAfter;
            EntityDetailCost = entityDetailCost;
            Avgcost = avgcost;
            InventoryItemLocationBatchFk = inventoryItemLocationBatchFk;
            IsActive = isActive;
        }
    }
}
