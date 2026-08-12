using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SecRole
{
    public long RoleId { get; set; }

    public string? RoleName { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsAdmin { get; set; }

    public string? RoleNameAr { get; set; }

    public bool? SingleSession { get; set; }

    public virtual ICollection<SecRoleModelAttribute> SecRoleModelAttributes { get; set; } = new List<SecRoleModelAttribute>();

    public virtual ICollection<SecRoleModule> SecRoleModules { get; set; } = new List<SecRoleModule>();

    public virtual ICollection<SecRoleProperty> SecRoleProperties { get; set; } = new List<SecRoleProperty>();

    public virtual ICollection<SecRoleViewAction> SecRoleViewActions { get; set; } = new List<SecRoleViewAction>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
