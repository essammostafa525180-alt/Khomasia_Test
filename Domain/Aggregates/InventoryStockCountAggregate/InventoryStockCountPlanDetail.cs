using Domain.Primitives;

namespace Domain.Aggregates.InventoryStockCountAggregate
{
    public class InventoryStockCountPlanDetail : AggregateRootEntityBase<int>
    {
        public InventoryStockCountPlanDetail()
        {
        }

        public InventoryStockCountPlanDetail(bool isActive) : this()
        {
            IsActive = isActive;
        }

        public static InventoryStockCountPlanDetail Create(bool isActive = false) => new InventoryStockCountPlanDetail(isActive);

        public void Update(bool isActive) => IsActive = isActive;
    }
}
