using Domain.Aggregates.UserAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class ApprovalMatrixConfigDetail : AggregateRootEntityBase<int>
    {
        public int? ApprovalMatrixConfigFk { get; set; }
        public int? ApprovalMatrixRangeFk { get; set; }
        public int StepNo { get; set; }
        public string? StepName { get; set; }
        public string? StepNameAr { get; set; }
        public int? UserFk { get; set; }
        public string? Email { get; set; }
        public ApprovalMatrixConfig? ApprovalMatrixConfigFkNavigation { get; set; }
        public ApprovalMatrixRange? ApprovalMatrixRangeFkNavigation { get; set; }
        public User? UserFkNavigation { get; set; }

        private List<ApprovalMatrixDetail> _approvalMatrixDetails = new List<ApprovalMatrixDetail>();
        public IReadOnlyCollection<ApprovalMatrixDetail> ApprovalMatrixDetails => _approvalMatrixDetails;

        public ApprovalMatrixConfigDetail()
        {
        }

        public ApprovalMatrixConfigDetail(int? approvalMatrixConfigFk, int? approvalMatrixRangeFk, int stepNo, string? stepName, string? stepNameAr, int? userFk, string? email, bool isActive) : this()
        {
            ApprovalMatrixConfigFk = approvalMatrixConfigFk;
            ApprovalMatrixRangeFk = approvalMatrixRangeFk;
            StepNo = stepNo;
            StepName = stepName;
            StepNameAr = stepNameAr;
            UserFk = userFk;
            Email = email;
            IsActive = isActive;
        }

        public static ApprovalMatrixConfigDetail Create(int? approvalMatrixConfigFk, int? approvalMatrixRangeFk, int stepNo, string? stepName, string? stepNameAr, int? userFk, string? email, bool isActive)
        {

            return new ApprovalMatrixConfigDetail(approvalMatrixConfigFk, approvalMatrixRangeFk, stepNo, stepName, stepNameAr, userFk, email, isActive);
        }

        public void Update(int? approvalMatrixConfigFk, int? approvalMatrixRangeFk, int stepNo, string? stepName, string? stepNameAr, int? userFk, string? email, bool isActive)
        {
            ApprovalMatrixConfigFk = approvalMatrixConfigFk;
            ApprovalMatrixRangeFk = approvalMatrixRangeFk;
            StepNo = stepNo;
            StepName = stepName;
            StepNameAr = stepNameAr;
            UserFk = userFk;
            Email = email;
            IsActive = isActive;
        }
    }
}
