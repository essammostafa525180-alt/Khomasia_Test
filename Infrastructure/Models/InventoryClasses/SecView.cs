using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SecView
{
    public long ViewId { get; set; }

    public string? ViewName { get; set; }

    public string? ViewDisplayName { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsVisibleToMenu { get; set; }

    public string? Url { get; set; }

    public long? SecModuleId { get; set; }

    public string? ViewDisplayNameAr { get; set; }

    public long? ParentId { get; set; }

    public int? Sequence { get; set; }

    public virtual ICollection<SecView> InverseParent { get; set; } = new List<SecView>();

    public virtual SecView? Parent { get; set; }

    public virtual SecModule? SecModule { get; set; }

    public virtual ICollection<SecViewAction> SecViewActions { get; set; } = new List<SecViewAction>();
}
