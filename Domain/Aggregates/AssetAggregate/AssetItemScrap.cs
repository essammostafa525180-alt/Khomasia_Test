using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.AssetAggregate
{
    public class AssetItemScrap : AggregateRootEntityBase<int>
    {
        public int? AssetItemFk { get; set; }
        public string? Code { get; set; }
        public int? AssetItemMoveFk { get; set; }
        public int? AssetItemMaintenanceFk { get; set; }
        public int? AssetScrapStatusFk { get; set; }
        public int? ApprovalStatusFk { get; set; }
        public decimal? SoldAmount { get; set; }
        public DateTime? ActionDate { get; set; }
        public ApprovalStatus? ApprovalStatusFkNavigation { get; set; }
        public AssetItem? AssetItemFkNavigation { get; set; }
        public AssetItemMaintenance? AssetItemMaintenanceFkNavigation { get; set; }
        public AssetItemMove? AssetItemMoveFkNavigation { get; set; }
        public AssetScrapStatus? AssetScrapStatusFkNavigation { get; set; }

        public AssetItemScrap()
        {
        }

        public AssetItemScrap(int? assetItemFk, string? code, int? assetItemMoveFk, int? assetItemMaintenanceFk, int? assetScrapStatusFk, int? approvalStatusFk, decimal? soldAmount, DateTime? actionDate, bool isActive) : this()
        {
            AssetItemFk = assetItemFk;
            Code = code;
            AssetItemMoveFk = assetItemMoveFk;
            AssetItemMaintenanceFk = assetItemMaintenanceFk;
            AssetScrapStatusFk = assetScrapStatusFk;
            ApprovalStatusFk = approvalStatusFk;
            SoldAmount = soldAmount;
            ActionDate = actionDate;
            IsActive = isActive;
        }

        public static AssetItemScrap Create(int? assetItemFk, string? code, int? assetItemMoveFk, int? assetItemMaintenanceFk, int? assetScrapStatusFk, int? approvalStatusFk, decimal? soldAmount, DateTime? actionDate, bool isActive)
        {

            return new AssetItemScrap(assetItemFk, code, assetItemMoveFk, assetItemMaintenanceFk, assetScrapStatusFk, approvalStatusFk, soldAmount, actionDate, isActive);
        }

        public void Update(int? assetItemFk, string? code, int? assetItemMoveFk, int? assetItemMaintenanceFk, int? assetScrapStatusFk, int? approvalStatusFk, decimal? soldAmount, DateTime? actionDate, bool isActive)
        {
            AssetItemFk = assetItemFk;
            Code = code;
            AssetItemMoveFk = assetItemMoveFk;
            AssetItemMaintenanceFk = assetItemMaintenanceFk;
            AssetScrapStatusFk = assetScrapStatusFk;
            ApprovalStatusFk = approvalStatusFk;
            SoldAmount = soldAmount;
            ActionDate = actionDate;
            IsActive = isActive;
        }
    }
}
