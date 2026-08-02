using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class VendorAttachment
{
    public long Id { get; set; }

    public long? AttachmentId { get; set; }

    public string? AttachmentName { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[]? RowVersion { get; set; }

    public long? VendorFk { get; set; }

    public virtual Vendor? VendorFkNavigation { get; set; }
}
