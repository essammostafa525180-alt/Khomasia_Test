using Domain.Aggregates.AssetAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class AssetWarrantyStatus : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<AssetItem> _assetItems = new List<AssetItem>();
        public IReadOnlyCollection<AssetItem> AssetItems => _assetItems;

        private AssetWarrantyStatus()
        {
        }

        public AssetWarrantyStatus(string? code, string? name, string? nameAr, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static AssetWarrantyStatus Create(string? code, string? name, string? nameAr, bool isActive)
        {

            return new AssetWarrantyStatus(code, name, nameAr, isActive);
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
