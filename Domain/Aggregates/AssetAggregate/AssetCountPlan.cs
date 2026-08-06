using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.AssetAggregate
{
    public class AssetCountPlan : AggregateRootEntityBase<int>
    {
        public string? PlanNumber { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? AssetCountPlanTypeFk { get; set; }
        public int? AssetCountPlanStatusFk { get; set; }
        public DateTime? PlaneDate { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public int? AssignedToUserFk { get; set; }
        public AssetCountPlanStatus? AssetCountPlanStatusFkNavigation { get; set; }
        public AssetCountPlanType? AssetCountPlanTypeFkNavigation { get; set; }

        private List<AssetCountPlanDetail> _assetCountPlanDetails = new List<AssetCountPlanDetail>();
        public IReadOnlyCollection<AssetCountPlanDetail> AssetCountPlanDetails => _assetCountPlanDetails;

        private List<AssetCount> _assetCounts = new List<AssetCount>();
        public IReadOnlyCollection<AssetCount> AssetCounts => _assetCounts;

        public AssetCountPlan()
        {
        }

        public AssetCountPlan(string? planNumber, string? name, string? nameAr, int? assetCountPlanTypeFk, int? assetCountPlanStatusFk, DateTime? planeDate, DateTime? executionDate, int? assignedToUserFk, bool isActive) : this()
        {
            PlanNumber = planNumber;
            Name = name;
            NameAr = nameAr;
            AssetCountPlanTypeFk = assetCountPlanTypeFk;
            AssetCountPlanStatusFk = assetCountPlanStatusFk;
            PlaneDate = planeDate;
            ExecutionDate = executionDate;
            AssignedToUserFk = assignedToUserFk;
            IsActive = isActive;
        }

        public static AssetCountPlan Create(string? planNumber, string? name, string? nameAr, int? assetCountPlanTypeFk, int? assetCountPlanStatusFk, DateTime? planeDate, DateTime? executionDate, int? assignedToUserFk, bool isActive)
        {

            return new AssetCountPlan(planNumber, name, nameAr, assetCountPlanTypeFk, assetCountPlanStatusFk, planeDate, executionDate, assignedToUserFk, isActive);
        }

        public void Update(string? planNumber, string? name, string? nameAr, int? assetCountPlanTypeFk, int? assetCountPlanStatusFk, DateTime? planeDate, DateTime? executionDate, int? assignedToUserFk, bool isActive)
        {
            PlanNumber = planNumber;
            Name = name;
            NameAr = nameAr;
            AssetCountPlanTypeFk = assetCountPlanTypeFk;
            AssetCountPlanStatusFk = assetCountPlanStatusFk;
            PlaneDate = planeDate;
            ExecutionDate = executionDate;
            AssignedToUserFk = assignedToUserFk;
            IsActive = isActive;
        }
    }
}
