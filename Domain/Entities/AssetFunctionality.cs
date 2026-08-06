using Domain.Aggregates.AssetAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class AssetFunctionality : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<AssetCommissioning> _assetCommissionings = new List<AssetCommissioning>();
        public IReadOnlyCollection<AssetCommissioning> AssetCommissionings => _assetCommissionings;

        private AssetFunctionality()
        {
        }

        public AssetFunctionality(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static AssetFunctionality Create(string? name, string? nameAr, bool isActive)
        {

            return new AssetFunctionality(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
