using Domain.Aggregates.ZoneAggregate;
using Domain.Primitives;

namespace Domain.Aggregates.AssetAggregate
{
    public class AssetCountPlanDetail : AggregateRootEntityBase<int>
    {
        public int? AssetCountPlanFk { get; set; }
        public int? ZoneFk { get; set; }
        public int? AssignedToUserFk { get; set; }
        public AssetCountPlan? AssetCountPlanFkNavigation { get; set; }
        public Zone? ZoneFkNavigation { get; set; }

        public AssetCountPlanDetail()
        {
        }

        public AssetCountPlanDetail(int? assetCountPlanFk, int? zoneFk, int? assignedToUserFk, bool isActive) : this()
        {
            AssetCountPlanFk = assetCountPlanFk;
            ZoneFk = zoneFk;
            AssignedToUserFk = assignedToUserFk;
            IsActive = isActive;
        }

        public static AssetCountPlanDetail Create(int? assetCountPlanFk, int? zoneFk, int? assignedToUserFk, bool isActive)
        {

            return new AssetCountPlanDetail(assetCountPlanFk, zoneFk, assignedToUserFk, isActive);
        }

        public void Update(int? assetCountPlanFk, int? zoneFk, int? assignedToUserFk, bool isActive)
        {
            AssetCountPlanFk = assetCountPlanFk;
            ZoneFk = zoneFk;
            AssignedToUserFk = assignedToUserFk;
            IsActive = isActive;
        }
    }
}
