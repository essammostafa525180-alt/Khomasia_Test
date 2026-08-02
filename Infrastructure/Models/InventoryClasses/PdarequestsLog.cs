using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class PdarequestsLog
{
    public long Id { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? RequestFk { get; set; }

    public long? AssignedToFk { get; set; }

    public bool? IsChanged { get; set; }

    public string? PdarequestType { get; set; }
}
