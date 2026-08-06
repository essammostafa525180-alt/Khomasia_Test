using Domain.Aggregates.ZoneAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.AssetAggregate
{
    public class AssetCount : AggregateRootEntityBase<int>
    {
        public string? AssetCountNumber { get; set; }
        public int? AssetTakerUserFk { get; set; }
        public DateTime? CountDate { get; set; }
        public int? ZoneFk { get; set; }
        public int? AssetCountPlanFk { get; set; }
        public AssetCountPlan? AssetCountPlanFkNavigation { get; set; }
        public Zone? ZoneFkNavigation { get; set; }

        private List<AssetCountDetail> _assetCountDetails = new List<AssetCountDetail>();
        public IReadOnlyCollection<AssetCountDetail> AssetCountDetails => _assetCountDetails;

        public AssetCount()
        {
        }

        public AssetCount(string? assetCountNumber, int? assetTakerUserFk, DateTime? countDate, int? zoneFk, int? assetCountPlanFk, bool isActive) : this()
        {
            AssetCountNumber = assetCountNumber;
            AssetTakerUserFk = assetTakerUserFk;
            CountDate = countDate;
            ZoneFk = zoneFk;
            AssetCountPlanFk = assetCountPlanFk;
            IsActive = isActive;
        }

        public static AssetCount Create(string? assetCountNumber, int? assetTakerUserFk, DateTime? countDate, int? zoneFk, int? assetCountPlanFk, bool isActive)
        {

            return new AssetCount(assetCountNumber, assetTakerUserFk, countDate, zoneFk, assetCountPlanFk, isActive);
        }

        public void Update(string? assetCountNumber, int? assetTakerUserFk, DateTime? countDate, int? zoneFk, int? assetCountPlanFk, bool isActive)
        {
            AssetCountNumber = assetCountNumber;
            AssetTakerUserFk = assetTakerUserFk;
            CountDate = countDate;
            ZoneFk = zoneFk;
            AssetCountPlanFk = assetCountPlanFk;
            IsActive = isActive;
        }
    }
}
