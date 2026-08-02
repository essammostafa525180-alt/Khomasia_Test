using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class AdUser
{
    public long Id { get; set; }

    public string? AdAccount { get; set; }

    public string? Mail { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
