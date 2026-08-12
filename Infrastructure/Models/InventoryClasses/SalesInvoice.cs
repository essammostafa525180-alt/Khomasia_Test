using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SalesInvoice
{
    public long Id { get; set; }

    public long? CustomerId { get; set; }

    public long? UserId { get; set; }

    public string? Address { get; set; }

    public string? ContactPerson { get; set; }

    public decimal? Vatpercentage { get; set; }

    public decimal? Vatamount { get; set; }

    public decimal? TotalAmount { get; set; }

    public DateTime? CreatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public long? UpdatedBy { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<SalesInvoiceItem> SalesInvoiceItems { get; set; } = new List<SalesInvoiceItem>();

    public virtual User? User { get; set; }
}
