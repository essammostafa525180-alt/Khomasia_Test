using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SecModule
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public string? ModuleName { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<SecModel> SecModels { get; set; } = new List<SecModel>();

    public virtual ICollection<SecProperty> SecProperties { get; set; } = new List<SecProperty>();

    public virtual ICollection<SecRoleModule> SecRoleModules { get; set; } = new List<SecRoleModule>();

    public virtual ICollection<SecUserModule> SecUserModules { get; set; } = new List<SecUserModule>();

    public virtual ICollection<SecView> SecViews { get; set; } = new List<SecView>();
}
