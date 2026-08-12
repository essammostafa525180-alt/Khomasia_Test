using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.AssetAggregate
{
    public class AssignAssetTypeToAssetGroup : AggregateRootEntityBase<int>
    {
        public int? AssetTypeFk { get; set; }
        public int? AssetGroupFk { get; set; }
        public AssetsGroup? AssetGroupFkNavigation { get; set; }
        public AssetsType? AssetTypeFkNavigation { get; set; }

        public AssignAssetTypeToAssetGroup()
        {
        }

        public AssignAssetTypeToAssetGroup(int? assetTypeFk, int? assetGroupFk, bool isActive) : this()
        {
            AssetTypeFk = assetTypeFk;
            AssetGroupFk = assetGroupFk;
            IsActive = isActive;
        }

        public static AssignAssetTypeToAssetGroup Create(int? assetTypeFk, int? assetGroupFk, bool isActive)
        {

            return new AssignAssetTypeToAssetGroup(assetTypeFk, assetGroupFk, isActive);
        }

        public void Update(int? assetTypeFk, int? assetGroupFk, bool isActive)
        {
            AssetTypeFk = assetTypeFk;
            AssetGroupFk = assetGroupFk;
            IsActive = isActive;
        }
    }
}
