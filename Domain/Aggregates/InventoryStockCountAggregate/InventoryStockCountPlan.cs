using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.InventoryStockCountAggregate
{
    public class InventoryStockCountPlan : AggregateRootEntityBase<int>
    {
        public string? CountPlanNo { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public DateTime? PlanDate { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public int? StockCountPlanStatusFk { get; set; }
        public int? StockCountPlanTypeFk { get; set; }
        public int? AssignedToUserFk { get; set; }
        public StockCountPlanStatus? StockCountPlanStatusFkNavigation { get; set; }
        public StockCountPlanType? StockCountPlanTypeFkNavigation { get; set; }

        private List<InventoryStockCountPlanDetail> _inventoryStockCountPlanDetails = new List<InventoryStockCountPlanDetail>();
        public IReadOnlyCollection<InventoryStockCountPlanDetail> InventoryStockCountPlanDetails => _inventoryStockCountPlanDetails;

        public InventoryStockCountPlan()
        {
        }

        public InventoryStockCountPlan(string? countPlanNo, string? name, string? nameAr, DateTime? planDate, DateTime? executionDate, int? stockCountPlanStatusFk, int? stockCountPlanTypeFk, int? assignedToUserFk, bool isActive) : this()
        {
            CountPlanNo = countPlanNo;
            Name = name;
            NameAr = nameAr;
            PlanDate = planDate;
            ExecutionDate = executionDate;
            StockCountPlanStatusFk = stockCountPlanStatusFk;
            StockCountPlanTypeFk = stockCountPlanTypeFk;
            AssignedToUserFk = assignedToUserFk;
            IsActive = isActive;
        }

        public static InventoryStockCountPlan Create(string? countPlanNo, string? name, string? nameAr, DateTime? planDate, DateTime? executionDate, int? stockCountPlanStatusFk, int? stockCountPlanTypeFk, int? assignedToUserFk, bool isActive)
        {

            return new InventoryStockCountPlan(countPlanNo, name, nameAr, planDate, executionDate, stockCountPlanStatusFk, stockCountPlanTypeFk, assignedToUserFk, isActive);
        }

        public void Update(string? countPlanNo, string? name, string? nameAr, DateTime? planDate, DateTime? executionDate, int? stockCountPlanStatusFk, int? stockCountPlanTypeFk, int? assignedToUserFk, bool isActive)
        {
            CountPlanNo = countPlanNo;
            Name = name;
            NameAr = nameAr;
            PlanDate = planDate;
            ExecutionDate = executionDate;
            StockCountPlanStatusFk = stockCountPlanStatusFk;
            StockCountPlanTypeFk = stockCountPlanTypeFk;
            AssignedToUserFk = assignedToUserFk;
            IsActive = isActive;
        }
    }
}
