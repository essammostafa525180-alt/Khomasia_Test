using Domain.Aggregates.InventoryTransfereAggregate;
using Domain.Aggregates.RequestAggregate;
using Domain.Aggregates.VendorReturnAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class ApprovalMatrix : AggregateRootEntityBase<int>
    {
        public int? ScreenFk { get; set; }
        public int? EntityId { get; set; }
        public int? ApprovalMatrixConfigFk { get; set; }
        public int ApprovalStatusFk { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public ApprovalMatrixConfig? ApprovalMatrixConfigFkNavigation { get; set; }
        public ApprovalStatus? ApprovalStatusFkNavigation { get; set; }
        public InventoryTransfere? Entity { get; set; }
        public PurchaseOrderService? Entity1 { get; set; }
        public VendorOrder? Entity2 { get; set; }
        public VendorReturn? Entity3 { get; set; }
        public InventroyItemRequestWithdraw? EntityNavigation { get; set; }
        public ApprovalScreen? ScreenFkNavigation { get; set; }

        private List<ApprovalMatrixDetail> _approvalMatrixDetails = new List<ApprovalMatrixDetail>();
        public IReadOnlyCollection<ApprovalMatrixDetail> ApprovalMatrixDetails => _approvalMatrixDetails;

        public ApprovalMatrix()
        {
        }

        public ApprovalMatrix(int? screenFk, int? entityId, int? approvalMatrixConfigFk, int approvalStatusFk, DateTime? approvalDate, bool isActive) : this()
        {
            ScreenFk = screenFk;
            EntityId = entityId;
            ApprovalMatrixConfigFk = approvalMatrixConfigFk;
            ApprovalStatusFk = approvalStatusFk;
            ApprovalDate = approvalDate;
            IsActive = isActive;
        }

        public static ApprovalMatrix Create(int? screenFk, int? entityId, int? approvalMatrixConfigFk, int approvalStatusFk, DateTime? approvalDate, bool isActive)
        {

            return new ApprovalMatrix(screenFk, entityId, approvalMatrixConfigFk, approvalStatusFk, approvalDate, isActive);
        }

        public void Update(int? screenFk, int? entityId, int? approvalMatrixConfigFk, int approvalStatusFk, DateTime? approvalDate, bool isActive)
        {
            ScreenFk = screenFk;
            EntityId = entityId;
            ApprovalMatrixConfigFk = approvalMatrixConfigFk;
            ApprovalStatusFk = approvalStatusFk;
            ApprovalDate = approvalDate;
            IsActive = isActive;
        }
    }
}
