using Domain.Aggregates.AssetAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class AssetMaintenanceStatus : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<AssetItemMaintenance> _assetItemMaintenances = new List<AssetItemMaintenance>();
        public IReadOnlyCollection<AssetItemMaintenance> AssetItemMaintenances => _assetItemMaintenances;

        private AssetMaintenanceStatus()
        {
        }

        public AssetMaintenanceStatus(string? code, string? name, string? nameAr, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static AssetMaintenanceStatus Create(string? code, string? name, string? nameAr, bool isActive)
        {

            return new AssetMaintenanceStatus(code, name, nameAr, isActive);
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
