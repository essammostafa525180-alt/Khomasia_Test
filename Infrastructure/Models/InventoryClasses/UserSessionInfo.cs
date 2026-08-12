using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class UserSessionInfo
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public DateTime LastHit { get; set; }

    public DateTime ExpireAt { get; set; }

    public bool? RemeberMe { get; set; }

    public string? Language { get; set; }

    public string? ValidModules { get; set; }

    public Guid UserToken { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<UserSessionInfoDetail> UserSessionInfoDetails { get; set; } = new List<UserSessionInfoDetail>();
}
