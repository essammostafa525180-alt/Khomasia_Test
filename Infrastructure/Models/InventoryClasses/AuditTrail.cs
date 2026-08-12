using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class AuditTrail
{
    public int Id { get; set; }

    public string? TableName { get; set; }

    public string? Action { get; set; }

    public DateTime? ExecutedAt { get; set; }

    public long? UserId { get; set; }

    public long? EntityId { get; set; }

    public string? ClientComputerName { get; set; }

    public string? ClientIp { get; set; }

    public int? ParentAuditTrailId { get; set; }

    public virtual ICollection<AuditTrailDetail> AuditTrailDetails { get; set; } = new List<AuditTrailDetail>();

    public virtual ICollection<AuditTrail> InverseParentAuditTrail { get; set; } = new List<AuditTrail>();

    public virtual AuditTrail? ParentAuditTrail { get; set; }

    public virtual User? User { get; set; }
}
