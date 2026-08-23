using Domain.Entities;

namespace Infrastructure.Models.LookupTables;

/// <summary>Supplier Quotation</summary>
public class SupplierQuotation
{
    public int Id { get; set; }  // PK

    public string? SupplierQuotationNo { get; set; }
    public int? SupplierID { get; set; }
    public Supplier? Supplier { get; set; }
    public int? RequestForQuotationID { get; set; }
    public RequestForQuotation? RequestForQuotation { get; set; }= null;
    public string? Status { get; set; }
    public int? CurrencyID { get; set; }
    public InventoryCurrency? Currency { get; set; } = null;
    public string? Total { get; set; }
}
