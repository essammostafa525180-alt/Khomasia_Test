using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class ApprovalMatrixConfigDetail
{
    public long Id { get; set; }

    public long? ApprovalMatrixConfigFk { get; set; }

    public long? ApprovalMatrixRangeFk { get; set; }

    public int StepNo { get; set; }

    public string? StepName { get; set; }

    public string? StepNameAr { get; set; }

    public long? UserFk { get; set; }

    public string? Email { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ApprovalMatrixConfig? ApprovalMatrixConfigFkNavigation { get; set; }

    public virtual ICollection<ApprovalMatrixDetail> ApprovalMatrixDetails { get; set; } = new List<ApprovalMatrixDetail>();

    public virtual ApprovalMatrixRange? ApprovalMatrixRangeFkNavigation { get; set; }

    public virtual User? UserFkNavigation { get; set; }
}
