using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SecViewAction
{
    public long ViewActionId { get; set; }

    public long? ViewId { get; set; }

    public string? Action { get; set; }

    public bool? IsActive { get; set; }

    public string? ActionNameAr { get; set; }

    public string? ActionName { get; set; }

    public virtual ICollection<SecRoleViewAction> SecRoleViewActions { get; set; } = new List<SecRoleViewAction>();

    public virtual ICollection<SecUserViewAction> SecUserViewActions { get; set; } = new List<SecUserViewAction>();

    public virtual SecView? View { get; set; }
}
