using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class AssignVendorEvaluationCriterion
{
    public long Id { get; set; }

    public long? VendorFk { get; set; }

    public long? VendorEvaluationCriteriaFk { get; set; }

    public long? RankFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Rank? RankFkNavigation { get; set; }

    public virtual VendorEvaluationCriterion? VendorEvaluationCriteriaFkNavigation { get; set; }

    public virtual Vendor? VendorFkNavigation { get; set; }
}
