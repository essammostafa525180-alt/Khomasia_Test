using Domain.Aggregates.LocationAggregate;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class ApprovalMatrixConfig
{
    public long Id { get; set; }

    public long? ScreenFk { get; set; }

    public long? CompanyFk { get; set; }

    public long? ProjectFk { get; set; }

    public long? ScopeFk { get; set; }

    public long? ServiceMainCategoryFk { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public long? LocationFk { get; set; }

    public virtual ICollection<ApprovalMatrix> ApprovalMatrices { get; set; } = new List<ApprovalMatrix>();

    public virtual ICollection<ApprovalMatrixConfigDetail> ApprovalMatrixConfigDetails { get; set; } = new List<ApprovalMatrixConfigDetail>();

    public virtual Company? CompanyFkNavigation { get; set; }

    public virtual Location? LocationFkNavigation { get; set; }

    public virtual Project? ProjectFkNavigation { get; set; }

    public virtual Scope? ScopeFkNavigation { get; set; }

    public virtual ApprovalScreen? ScreenFkNavigation { get; set; }

    public virtual ServiceMainCategory? ServiceMainCategoryFkNavigation { get; set; }
}
