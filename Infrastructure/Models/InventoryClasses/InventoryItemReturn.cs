using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryItemReturn
{
    public long Id { get; set; }

    public long? RequestWithdrawFk { get; set; }

    public string? ReturnNo { get; set; }

    public DateTime? ReturnDate { get; set; }

    public long? ReturnedByFk { get; set; }

    public string? ReturnedBy { get; set; }

    public string? DescriptionEn { get; set; }

    public string? DescriptionAr { get; set; }

    public long? ItemReturnStatusFk { get; set; }

    public bool? IsAprove { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public bool? Axsynced { get; set; }

    public long? SourceId { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<InventoryItemReturnAttachment> InventoryItemReturnAttachments { get; set; } = new List<InventoryItemReturnAttachment>();

    public virtual ICollection<InventoryItemReturnDetail> InventoryItemReturnDetails { get; set; } = new List<InventoryItemReturnDetail>();

    public virtual ICollection<InventoryItemReturnSerial> InventoryItemReturnSerials { get; set; } = new List<InventoryItemReturnSerial>();

    public virtual ReturnStatus? ItemReturnStatusFkNavigation { get; set; }

    public virtual User? LastUpdatedByNavigation { get; set; }

    public virtual InventroyItemRequestWithdraw? RequestWithdrawFkNavigation { get; set; }

    public virtual User? ReturnedByFkNavigation { get; set; }
}
