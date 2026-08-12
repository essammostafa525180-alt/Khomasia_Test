using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class ApprovalMatrixDetail
{
    public long Id { get; set; }

    public long? ApprovalMatrixFk { get; set; }

    public long? ApprovalMatrixConfigDetailFk { get; set; }

    public long ApprovalStatusFk { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public long? UserFk { get; set; }

    public string? Email { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ApprovalMatrixConfigDetail? ApprovalMatrixConfigDetailFkNavigation { get; set; }

    public virtual ApprovalMatrix? ApprovalMatrixFkNavigation { get; set; }

    public virtual ApprovalStatus ApprovalStatusFkNavigation { get; set; } = null!;

    public virtual User? UserFkNavigation { get; set; }
}
