using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.AssetAggregate
{
    public class AssetItemMaintenance : AggregateRootEntityBase<int>
    {
        public int? AssetItemFk { get; set; }
        public string? Code { get; set; }
        public int? AssetItemMoveFk { get; set; }
        public int? AssetMaintenanceStatusFk { get; set; }
        public AssetItem? AssetItemFkNavigation { get; set; }
        public AssetItemMove? AssetItemMoveFkNavigation { get; set; }
        public AssetMaintenanceStatus? AssetMaintenanceStatusFkNavigation { get; set; }

        private List<AssetItemScrap> _assetItemScraps = new List<AssetItemScrap>();
        public IReadOnlyCollection<AssetItemScrap> AssetItemScraps => _assetItemScraps;

        public AssetItemMaintenance()
        {
        }

        public AssetItemMaintenance(int? assetItemFk, string? code, int? assetItemMoveFk, int? assetMaintenanceStatusFk, bool isActive) : this()
        {
            AssetItemFk = assetItemFk;
            Code = code;
            AssetItemMoveFk = assetItemMoveFk;
            AssetMaintenanceStatusFk = assetMaintenanceStatusFk;
            IsActive = isActive;
        }

        public static AssetItemMaintenance Create(int? assetItemFk, string? code, int? assetItemMoveFk, int? assetMaintenanceStatusFk, bool isActive)
        {

            return new AssetItemMaintenance(assetItemFk, code, assetItemMoveFk, assetMaintenanceStatusFk, isActive);
        }

        public void Update(int? assetItemFk, string? code, int? assetItemMoveFk, int? assetMaintenanceStatusFk, bool isActive)
        {
            AssetItemFk = assetItemFk;
            Code = code;
            AssetItemMoveFk = assetItemMoveFk;
            AssetMaintenanceStatusFk = assetMaintenanceStatusFk;
            IsActive = isActive;
        }
    }
}
