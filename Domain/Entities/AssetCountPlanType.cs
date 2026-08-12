using Domain.Aggregates.AssetAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class AssetCountPlanType : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<AssetCountPlan> _assetCountPlans = new List<AssetCountPlan>();
        public IReadOnlyCollection<AssetCountPlan> AssetCountPlans => _assetCountPlans;

        private AssetCountPlanType()
        {
        }

        public AssetCountPlanType(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static AssetCountPlanType Create(string? name, string? nameAr, bool isActive)
        {

            return new AssetCountPlanType(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
