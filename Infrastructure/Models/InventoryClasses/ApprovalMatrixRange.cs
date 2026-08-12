using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class ApprovalMatrixRange
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public decimal? RangeFrom { get; set; }

    public decimal? RangeTo { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<ApprovalMatrixConfigDetail> ApprovalMatrixConfigDetails { get; set; } = new List<ApprovalMatrixConfigDetail>();
}
