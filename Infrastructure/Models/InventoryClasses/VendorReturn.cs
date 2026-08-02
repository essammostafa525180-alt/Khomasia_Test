using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class VendorReturn
{
    public long Id { get; set; }

    public long? VendorOrderReceiveFk { get; set; }

    public string? ReturnNo { get; set; }

    public DateTime? ReturnDate { get; set; }

    public string? ReturnedBy { get; set; }

    public long? ReturnedByUserFk { get; set; }

    public string? DescriptionEn { get; set; }

    public string? DescriptionAr { get; set; }

    public long? ReturnStatusFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public bool? Axsynced { get; set; }

    public bool? IsEmailSent { get; set; }

    public bool? IsApproved { get; set; }

    public virtual ICollection<ApprovalMatrix> ApprovalMatrices { get; set; } = new List<ApprovalMatrix>();

    public virtual ReturnStatus? ReturnStatusFkNavigation { get; set; }

    public virtual VendorOrderReceive? VendorOrderReceiveFkNavigation { get; set; }

    public virtual ICollection<VendorReturnAttachment> VendorReturnAttachments { get; set; } = new List<VendorReturnAttachment>();

    public virtual ICollection<VendorReturnDetail> VendorReturnDetails { get; set; } = new List<VendorReturnDetail>();

    public virtual ICollection<VendorReturnSerial> VendorReturnSerials { get; set; } = new List<VendorReturnSerial>();
}
