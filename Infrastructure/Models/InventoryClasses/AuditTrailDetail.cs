using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class AuditTrailDetail
{
    public int Id { get; set; }

    public int? AuditTrailId { get; set; }

    public string? Property { get; set; }

    public string? OldValue { get; set; }

    public string? NewValue { get; set; }

    public string? ReferenceTable { get; set; }

    public virtual AuditTrail? AuditTrail { get; set; }
}
