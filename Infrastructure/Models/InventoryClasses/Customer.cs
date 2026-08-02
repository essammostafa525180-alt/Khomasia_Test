using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Customer
{
    public long Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? ContactPerson { get; set; }

    public string? CommercialRecord { get; set; }

    public string? OtherVendor { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public long? CompanyFk { get; set; }

    public long? SectorFk { get; set; }

    public virtual ICollection<SalesInvoice> SalesInvoices { get; set; } = new List<SalesInvoice>();

    public virtual ICollection<SalesQuotation> SalesQuotations { get; set; } = new List<SalesQuotation>();

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
