using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class UserSessionInfoDetail
{
    public long Id { get; set; }

    public long? UserSessionInfoId { get; set; }

    public long? InfoKey { get; set; }

    public string? InfoValue { get; set; }

    public string? InfoDescription { get; set; }

    public virtual UserSessionInfo? UserSessionInfo { get; set; }
}
