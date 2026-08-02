using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class ApprovalScreen
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<ApprovalMatrix> ApprovalMatrices { get; set; } = new List<ApprovalMatrix>();

    public virtual ICollection<ApprovalMatrixConfig> ApprovalMatrixConfigs { get; set; } = new List<ApprovalMatrixConfig>();

    public virtual ICollection<Pruser> Prusers { get; set; } = new List<Pruser>();
}
