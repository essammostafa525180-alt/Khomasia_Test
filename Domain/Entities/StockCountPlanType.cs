using Domain.Aggregates.InventoryStockCountAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class StockCountPlanType : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<InventoryStockCountPlan> _inventoryStockCountPlans = new List<InventoryStockCountPlan>();
        public IReadOnlyCollection<InventoryStockCountPlan> InventoryStockCountPlans => _inventoryStockCountPlans;

        private StockCountPlanType()
        {
        }

        public StockCountPlanType(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static StockCountPlanType Create(string? name, string? nameAr, bool isActive)
        {

            return new StockCountPlanType(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
