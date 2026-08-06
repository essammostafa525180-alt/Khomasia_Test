using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.AssetAggregate
{
    public class AssetCommissioning : AggregateRootEntityBase<int>
    {
        public int? AssetFk { get; set; }
        public int? CommissionConditionFk { get; set; }
        public int? AssetFunctionalityFk { get; set; }
        public int? AssetComplineFk { get; set; }
        public int? SubSectionFk { get; set; }
        public AssetCompline? AssetComplineFkNavigation { get; set; }
        public Asset? AssetFkNavigation { get; set; }
        public AssetFunctionality? AssetFunctionalityFkNavigation { get; set; }
        public CommissionCondition? CommissionConditionFkNavigation { get; set; }
        public SubSection? SubSectionFkNavigation { get; set; }

        public AssetCommissioning()
        {
        }

        public AssetCommissioning(int? assetFk, int? commissionConditionFk, int? assetFunctionalityFk, int? assetComplineFk, int? subSectionFk, bool isActive) : this()
        {
            AssetFk = assetFk;
            CommissionConditionFk = commissionConditionFk;
            AssetFunctionalityFk = assetFunctionalityFk;
            AssetComplineFk = assetComplineFk;
            SubSectionFk = subSectionFk;
            IsActive = isActive;
        }

        public static AssetCommissioning Create(int? assetFk, int? commissionConditionFk, int? assetFunctionalityFk, int? assetComplineFk, int? subSectionFk, bool isActive)
        {

            return new AssetCommissioning(assetFk, commissionConditionFk, assetFunctionalityFk, assetComplineFk, subSectionFk, isActive);
        }

        public void Update(int? assetFk, int? commissionConditionFk, int? assetFunctionalityFk, int? assetComplineFk, int? subSectionFk, bool isActive)
        {
            AssetFk = assetFk;
            CommissionConditionFk = commissionConditionFk;
            AssetFunctionalityFk = assetFunctionalityFk;
            AssetComplineFk = assetComplineFk;
            SubSectionFk = subSectionFk;
            IsActive = isActive;
        }
    }
}
