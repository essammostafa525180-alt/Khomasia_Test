using Domain.Aggregates.AssetAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class AssetCountStatus : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<AssetCountDetail> _assetCountDetails = new List<AssetCountDetail>();
        public IReadOnlyCollection<AssetCountDetail> AssetCountDetails => _assetCountDetails;

        private AssetCountStatus()
        {
        }

        public AssetCountStatus(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static AssetCountStatus Create(string? name, string? nameAr, bool isActive)
        {

            return new AssetCountStatus(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
