using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class WsLastSyncTable
{
    public int Id { get; set; }

    public string? Key { get; set; }

    public string? Value { get; set; }
}
