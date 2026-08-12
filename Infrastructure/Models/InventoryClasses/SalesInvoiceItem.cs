using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SalesInvoiceItem
{
    public long Id { get; set; }

    public long? SalesInvoiceId { get; set; }

    public long? ProductId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public decimal? Discount { get; set; }

    public decimal? NetAmount { get; set; }

    public DateTime? CreatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public long? UpdatedBy { get; set; }

    public virtual SalesInvoice? SalesInvoice { get; set; }
}
