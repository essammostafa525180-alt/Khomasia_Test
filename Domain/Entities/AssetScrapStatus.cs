using Domain.Aggregates.AssetAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class AssetScrapStatus : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<AssetItemScrap> _assetItemScraps = new List<AssetItemScrap>();
        public IReadOnlyCollection<AssetItemScrap> AssetItemScraps => _assetItemScraps;

        private AssetScrapStatus()
        {
        }

        public AssetScrapStatus(string? code, string? name, string? nameAr, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static AssetScrapStatus Create(string? code, string? name, string? nameAr, bool isActive)
        {

            return new AssetScrapStatus(code, name, nameAr, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
