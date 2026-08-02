using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SecModelAttribute
{
    public long ModelAttributeId { get; set; }

    public long? ModelId { get; set; }

    public string? AttributeName { get; set; }

    public bool? IsActive { get; set; }

    public string? AttributeDisplayName { get; set; }

    public string? AttributeDisplayNameAr { get; set; }

    public virtual SecModel? Model { get; set; }

    public virtual ICollection<SecRoleModelAttribute> SecRoleModelAttributes { get; set; } = new List<SecRoleModelAttribute>();

    public virtual ICollection<SecUserModelAtrribute> SecUserModelAtrributes { get; set; } = new List<SecUserModelAtrribute>();
}
