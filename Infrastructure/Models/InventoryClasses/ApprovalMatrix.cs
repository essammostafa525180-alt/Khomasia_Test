using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class ApprovalMatrix
{
    public long Id { get; set; }

    public long? ScreenFk { get; set; }

    public long? EntityId { get; set; }

    public long? ApprovalMatrixConfigFk { get; set; }

    public long ApprovalStatusFk { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ApprovalMatrixConfig? ApprovalMatrixConfigFkNavigation { get; set; }

    public virtual ICollection<ApprovalMatrixDetail> ApprovalMatrixDetails { get; set; } = new List<ApprovalMatrixDetail>();

    public virtual ApprovalStatus ApprovalStatusFkNavigation { get; set; } = null!;

    public virtual InventoryTransfere? Entity { get; set; }

    public virtual PurchaseOrderService? Entity1 { get; set; }

    public virtual VendorOrder? Entity2 { get; set; }

    public virtual VendorReturn? Entity3 { get; set; }

    public virtual InventroyItemRequestWithdraw? EntityNavigation { get; set; }

    public virtual ApprovalScreen? ScreenFkNavigation { get; set; }
}
