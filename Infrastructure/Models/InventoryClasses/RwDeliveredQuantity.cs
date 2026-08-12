using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class RwDeliveredQuantity
{
    public long Id { get; set; }

    public long? RequestWdfk { get; set; }

    public decimal? DeliveredQuantity { get; set; }

    public decimal? ScrapedQuantity { get; set; }

    public DateTime? DeliveredDate { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public bool? Axsynced { get; set; }

    public bool? IsReceived { get; set; }

    public decimal? MaintainableQuantity { get; set; }

    public string? DeliveredNumber { get; set; }

    public virtual InventroyItemRequestWithdrawDetail? RequestWdfkNavigation { get; set; }

    public virtual ICollection<RequestWithdrawSerial> RequestWithdrawSerials { get; set; } = new List<RequestWithdrawSerial>();
}
