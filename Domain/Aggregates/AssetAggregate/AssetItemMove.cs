using Domain.Aggregates.CompanyAggregate;
using Domain.Aggregates.LocationAggregate;
using Domain.Aggregates.UserAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.AssetAggregate
{
    public class AssetItemMove : AggregateRootEntityBase<int>
    {
        public string? Code { get; set; }
        public int? AssetItemFk { get; set; }
        public int? AssetMoveTypeFk { get; set; }
        public int? FromProjectFk { get; set; }
        public int? FromAssetLocationFk { get; set; }
        public int? ToProjectFk { get; set; }
        public int? ToAssetLocationFk { get; set; }
        public int? EmployeeFk { get; set; }
        public DateOnly? MoveDate { get; set; }
        public int? OwnerApprovedFk { get; set; }
        public int? IsOwnerApprovedFk { get; set; }
        public DateTime? OwnerApprovedDate { get; set; }
        public int? ManagerApprovedFk { get; set; }
        public int? IsManagerApprovedFk { get; set; }
        public DateTime? ManagerApprovedDate { get; set; }
        public AssetItem? AssetItemFkNavigation { get; set; }
        public AssetMoveType? AssetMoveTypeFkNavigation { get; set; }
        public Employee? EmployeeFkNavigation { get; set; }
        public Location? FromAssetLocationFkNavigation { get; set; }
        public Project? FromProjectFkNavigation { get; set; }
        public ApprovalStatus? IsManagerApprovedFkNavigation { get; set; }
        public ApprovalStatus? IsOwnerApprovedFkNavigation { get; set; }
        public Employee? ManagerApprovedFkNavigation { get; set; }
        public Employee? OwnerApprovedFkNavigation { get; set; }
        public Location? ToAssetLocationFkNavigation { get; set; }
        public Project? ToProjectFkNavigation { get; set; }

        private List<AssetItemMaintenance> _assetItemMaintenances = new List<AssetItemMaintenance>();
        public IReadOnlyCollection<AssetItemMaintenance> AssetItemMaintenances => _assetItemMaintenances;

        private List<AssetItemScrap> _assetItemScraps = new List<AssetItemScrap>();
        public IReadOnlyCollection<AssetItemScrap> AssetItemScraps => _assetItemScraps;

        public AssetItemMove()
        {
        }

        public AssetItemMove(string? code, int? assetItemFk, int? assetMoveTypeFk, int? fromProjectFk, int? fromAssetLocationFk, int? toProjectFk, int? toAssetLocationFk, int? employeeFk, DateOnly? moveDate, int? ownerApprovedFk, int? isOwnerApprovedFk, DateTime? ownerApprovedDate, int? managerApprovedFk, int? isManagerApprovedFk, DateTime? managerApprovedDate, bool isActive) : this()
        {
            Code = code;
            AssetItemFk = assetItemFk;
            AssetMoveTypeFk = assetMoveTypeFk;
            FromProjectFk = fromProjectFk;
            FromAssetLocationFk = fromAssetLocationFk;
            ToProjectFk = toProjectFk;
            ToAssetLocationFk = toAssetLocationFk;
            EmployeeFk = employeeFk;
            MoveDate = moveDate;
            OwnerApprovedFk = ownerApprovedFk;
            IsOwnerApprovedFk = isOwnerApprovedFk;
            OwnerApprovedDate = ownerApprovedDate;
            ManagerApprovedFk = managerApprovedFk;
            IsManagerApprovedFk = isManagerApprovedFk;
            ManagerApprovedDate = managerApprovedDate;
            IsActive = isActive;
        }

        public static AssetItemMove Create(string? code, int? assetItemFk, int? assetMoveTypeFk, int? fromProjectFk, int? fromAssetLocationFk, int? toProjectFk, int? toAssetLocationFk, int? employeeFk, DateOnly? moveDate, int? ownerApprovedFk, int? isOwnerApprovedFk, DateTime? ownerApprovedDate, int? managerApprovedFk, int? isManagerApprovedFk, DateTime? managerApprovedDate, bool isActive)
        {

            return new AssetItemMove(code, assetItemFk, assetMoveTypeFk, fromProjectFk, fromAssetLocationFk, toProjectFk, toAssetLocationFk, employeeFk, moveDate, ownerApprovedFk, isOwnerApprovedFk, ownerApprovedDate, managerApprovedFk, isManagerApprovedFk, managerApprovedDate, isActive);
        }

        public void Update(string? code, int? assetItemFk, int? assetMoveTypeFk, int? fromProjectFk, int? fromAssetLocationFk, int? toProjectFk, int? toAssetLocationFk, int? employeeFk, DateOnly? moveDate, int? ownerApprovedFk, int? isOwnerApprovedFk, DateTime? ownerApprovedDate, int? managerApprovedFk, int? isManagerApprovedFk, DateTime? managerApprovedDate, bool isActive)
        {
            Code = code;
            AssetItemFk = assetItemFk;
            AssetMoveTypeFk = assetMoveTypeFk;
            FromProjectFk = fromProjectFk;
            FromAssetLocationFk = fromAssetLocationFk;
            ToProjectFk = toProjectFk;
            ToAssetLocationFk = toAssetLocationFk;
            EmployeeFk = employeeFk;
            MoveDate = moveDate;
            OwnerApprovedFk = ownerApprovedFk;
            IsOwnerApprovedFk = isOwnerApprovedFk;
            OwnerApprovedDate = ownerApprovedDate;
            ManagerApprovedFk = managerApprovedFk;
            IsManagerApprovedFk = isManagerApprovedFk;
            ManagerApprovedDate = managerApprovedDate;
            IsActive = isActive;
        }
    }
}
