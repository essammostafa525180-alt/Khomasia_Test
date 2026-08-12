using Domain.Aggregates.VendorOrderAggregate;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class VendorOrderVendorSuggested
{
    public long Id { get; set; }

    public long? VendorOrderFk { get; set; }

    public string? VendorName { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Website { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public virtual VendorOrder? VendorOrderFkNavigation { get; set; }
}
