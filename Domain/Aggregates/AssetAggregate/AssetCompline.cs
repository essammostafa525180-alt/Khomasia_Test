using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.AssetAggregate
{
    public class AssetCompline : AggregateRootEntityBase<int>
    {
        public string? Name { get; set; }
        public string? NameAr { get; set; }

        private List<AssetCommissioning> _assetCommissionings = new List<AssetCommissioning>();
        public IReadOnlyCollection<AssetCommissioning> AssetCommissionings => _assetCommissionings;

        public AssetCompline()
        {
        }

        public AssetCompline(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static AssetCompline Create(string? name, string? nameAr, bool isActive)
        {

            return new AssetCompline(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
