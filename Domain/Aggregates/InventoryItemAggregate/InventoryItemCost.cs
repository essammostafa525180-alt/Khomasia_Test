using Domain.Aggregates.CompanyAggregate;
using Domain.Primitives;

namespace Domain.Aggregates.InventoryItemAggregate
{
    public class InventoryItemCost : AggregateRootEntityBase<int>
    {
        public long? InventoryItemFk { get; set; }
        public int? CompanyFk { get; set; }
        public decimal? AvgCost { get; set; }
        public decimal? TotalQuantity { get; set; }
        public Company? CompanyFkNavigation { get; set; }
        public InventoryItem? InventoryItemFkNavigation { get; set; }

        public InventoryItemCost()
        {
        }

        public InventoryItemCost(long? inventoryItemFk, int? companyFk, decimal? avgCost, decimal? totalQuantity, bool isActive) : this()
        {
            InventoryItemFk = inventoryItemFk;
            CompanyFk = companyFk;
            AvgCost = avgCost;
            TotalQuantity = totalQuantity;
            IsActive = isActive;
        }

        public static InventoryItemCost Create(long? inventoryItemFk, int? companyFk, decimal? avgCost, decimal? totalQuantity, bool isActive)
        {

            return new InventoryItemCost(inventoryItemFk, companyFk, avgCost, totalQuantity, isActive);
        }

        public void Update(long? inventoryItemFk, int? companyFk, decimal? avgCost, decimal? totalQuantity, bool isActive)
        {
            InventoryItemFk = inventoryItemFk;
            CompanyFk = companyFk;
            AvgCost = avgCost;
            TotalQuantity = totalQuantity;
            IsActive = isActive;
        }
    }
}
