using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class ViewRequestStatus
{
    public long PurchaseRequestFk { get; set; }

    public decimal? TotalRequestedQuantity { get; set; }

    public decimal? TotalOrderedQuantity { get; set; }

    public int RequestOrderStatusId { get; set; }
}
