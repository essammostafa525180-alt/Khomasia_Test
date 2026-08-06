using Domain.Aggregates.AssetAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class CommissionCondition : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<AssetCommissioning> _assetCommissionings = new List<AssetCommissioning>();
        public IReadOnlyCollection<AssetCommissioning> AssetCommissionings => _assetCommissionings;

        private CommissionCondition()
        {
        }

        public CommissionCondition(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static CommissionCondition Create(string? name, string? nameAr, bool isActive)
        {

            return new CommissionCondition(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
