using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class AssetCommissioning
{
    public long Id { get; set; }

    public long? AssetFk { get; set; }

    public long? CommissionConditionFk { get; set; }

    public long? AssetFunctionalityFk { get; set; }

    public long? AssetComplineFk { get; set; }

    public long? SubSectionFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual AssetCompline? AssetComplineFkNavigation { get; set; }

    public virtual Asset? AssetFkNavigation { get; set; }

    public virtual AssetFunctionality? AssetFunctionalityFkNavigation { get; set; }

    public virtual CommissionCondition? CommissionConditionFkNavigation { get; set; }

    public virtual SubSection? SubSectionFkNavigation { get; set; }
}
