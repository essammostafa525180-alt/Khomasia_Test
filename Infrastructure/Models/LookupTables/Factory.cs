

using Domain.Enums;
using Infrastructure.Models.InventoryClasses;

namespace Infrastructure.Models.LookupTables;

/// <summary>Supplier Invoice</summary>
public class SupplierInvoice
{
    public int Id { get; set; }  // PK
    public string? InvoiceNo { get; set; }
    public int? SupplierID { get; set; }
    public Supplier? Supplier { get; set; } = null;
    public int POID { get; set; }
    public PurchaseOrder? PurchaseOrder { get; set; }
    public int? GRNID { get; set; } // FK -> GoodsReceipt
    public GoodsReceipt? GoodsReceipt { get; set; }
    public decimal? Amount { get; set; }
    public int? CurrencyID { get; set; }
    public InventoryCurrency? Currency { get; set; }
    public bool? Matchstatus { get; set; }
}
