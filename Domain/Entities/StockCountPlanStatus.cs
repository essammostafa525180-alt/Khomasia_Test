using Domain.Aggregates.InventoryStockCountAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class StockCountPlanStatus : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<InventoryStockCountPlan> _inventoryStockCountPlans = new List<InventoryStockCountPlan>();
        public IReadOnlyCollection<InventoryStockCountPlan> InventoryStockCountPlans => _inventoryStockCountPlans;

        private StockCountPlanStatus()
        {
        }

        public StockCountPlanStatus(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static StockCountPlanStatus Create(string? name, string? nameAr, bool isActive)
        {

            return new StockCountPlanStatus(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
