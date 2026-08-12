using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class NotFoundItem
{
    public string? ItemCode { get; set; }

    public string? Store { get; set; }

    public double? Balance { get; set; }

    public DateTime? Date { get; set; }

    public string? Id { get; set; }

    public string? Code { get; set; }

    public string? Duplicated { get; set; }
}
