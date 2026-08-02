using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class PoserviceTermsAndCondition
{
    public long Id { get; set; }

    public long? PoserviceFk { get; set; }

    public long? TermsAndConditionFk { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive1 { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual TermsAndCondition? TermsAndConditionFkNavigation { get; set; }
}
