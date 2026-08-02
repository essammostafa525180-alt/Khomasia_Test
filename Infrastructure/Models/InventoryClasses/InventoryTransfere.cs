using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryTransfere
{
    public long Id { get; set; }

    public string? TransferNumber { get; set; }

    public DateTime? TransferDate { get; set; }

    public long? FromStoreFk { get; set; }

    public long? ToStoreFk { get; set; }

    public long? TransferredByUserFk { get; set; }

    public long? ReceivedByUserFk { get; set; }

    public string? Notes { get; set; }

    public long? TransferReasonFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public bool? Axsynced { get; set; }

    public long? TransferStatusFk { get; set; }

    public long? CompanyFromFk { get; set; }

    public long? CompanyToFk { get; set; }

    public bool? IsReceived { get; set; }

    public long? ItemTypeFk { get; set; }

    public bool? IsApproved { get; set; }

    public virtual ICollection<ApprovalMatrix> ApprovalMatrices { get; set; } = new List<ApprovalMatrix>();

    public virtual Company? CompanyFromFkNavigation { get; set; }

    public virtual Company? CompanyToFkNavigation { get; set; }

    public virtual Store? FromStoreFkNavigation { get; set; }

    public virtual ICollection<InventoryTransfereAttachment> InventoryTransfereAttachments { get; set; } = new List<InventoryTransfereAttachment>();

    public virtual ICollection<InventoryTransfereDetail> InventoryTransfereDetails { get; set; } = new List<InventoryTransfereDetail>();

    public virtual ICollection<InventoryTransfereSerial> InventoryTransfereSerials { get; set; } = new List<InventoryTransfereSerial>();

    public virtual ItemType? ItemTypeFkNavigation { get; set; }

    public virtual Store? ToStoreFkNavigation { get; set; }

    public virtual TransferReason? TransferReasonFkNavigation { get; set; }

    public virtual TransferStatus? TransferStatusFkNavigation { get; set; }
}
