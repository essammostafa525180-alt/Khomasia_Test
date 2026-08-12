using Domain.Aggregates.UserAggregate;
using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class ApprovalMatrixDetail : AggregateRootEntityBase<int>
    {
        public int? ApprovalMatrixFk { get; set; }
        public int? ApprovalMatrixConfigDetailFk { get; set; }
        public int ApprovalStatusFk { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int? UserFk { get; set; }
        public string? Email { get; set; }
        public ApprovalMatrixConfigDetail? ApprovalMatrixConfigDetailFkNavigation { get; set; }
        public ApprovalMatrix? ApprovalMatrixFkNavigation { get; set; }
        public ApprovalStatus? ApprovalStatusFkNavigation { get; set; }
        public User? UserFkNavigation { get; set; }

        public ApprovalMatrixDetail()
        {
        }

        public ApprovalMatrixDetail(int? approvalMatrixFk, int? approvalMatrixConfigDetailFk, int approvalStatusFk, DateTime? approvalDate, int? userFk, string? email, bool isActive) : this()
        {
            ApprovalMatrixFk = approvalMatrixFk;
            ApprovalMatrixConfigDetailFk = approvalMatrixConfigDetailFk;
            ApprovalStatusFk = approvalStatusFk;
            ApprovalDate = approvalDate;
            UserFk = userFk;
            Email = email;
            IsActive = isActive;
        }

        public static ApprovalMatrixDetail Create(int? approvalMatrixFk, int? approvalMatrixConfigDetailFk, int approvalStatusFk, DateTime? approvalDate, int? userFk, string? email, bool isActive)
        {

            return new ApprovalMatrixDetail(approvalMatrixFk, approvalMatrixConfigDetailFk, approvalStatusFk, approvalDate, userFk, email, isActive);
        }

        public void Update(int? approvalMatrixFk, int? approvalMatrixConfigDetailFk, int approvalStatusFk, DateTime? approvalDate, int? userFk, string? email, bool isActive)
        {
            ApprovalMatrixFk = approvalMatrixFk;
            ApprovalMatrixConfigDetailFk = approvalMatrixConfigDetailFk;
            ApprovalStatusFk = approvalStatusFk;
            ApprovalDate = approvalDate;
            UserFk = userFk;
            Email = email;
            IsActive = isActive;
        }
    }
}
