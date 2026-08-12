using Domain.Aggregates.AssetAggregate;
using Domain.Aggregates.VendorOrderAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ApprovalStatus : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<ApprovalMatrix> _approvalMatrices = new List<ApprovalMatrix>();
        public IReadOnlyCollection<ApprovalMatrix> ApprovalMatrices => _approvalMatrices;

        private List<ApprovalMatrixDetail> _approvalMatrixDetails = new List<ApprovalMatrixDetail>();
        public IReadOnlyCollection<ApprovalMatrixDetail> ApprovalMatrixDetails => _approvalMatrixDetails;

        private List<AssetItemMove> _assetItemMoveIsManagerApprovedFkNavigations = new List<AssetItemMove>();
        public IReadOnlyCollection<AssetItemMove> AssetItemMoveIsManagerApprovedFkNavigations => _assetItemMoveIsManagerApprovedFkNavigations;

        private List<AssetItemMove> _assetItemMoveIsOwnerApprovedFkNavigations = new List<AssetItemMove>();
        public IReadOnlyCollection<AssetItemMove> AssetItemMoveIsOwnerApprovedFkNavigations => _assetItemMoveIsOwnerApprovedFkNavigations;

        private List<AssetItemScrap> _assetItemScraps = new List<AssetItemScrap>();
        public IReadOnlyCollection<AssetItemScrap> AssetItemScraps => _assetItemScraps;

        private ApprovalStatus()
        {
        }

        public ApprovalStatus(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static ApprovalStatus Create(string? name, string? nameAr, bool isActive)
        {

            return new ApprovalStatus(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
