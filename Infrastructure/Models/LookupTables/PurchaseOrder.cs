using Domain.Entities;
using Warehouse = Domain.Entities.Warehouse;

namespace Infrastructure.Models.LookupTables;
/// <summary>
/// PO Table 
/// </summary>
public class PurchaseOrder 
{
    public int PurchaseOrderId { get; set; }  // PK
    public string? PurchaseOrderNo { get; set; }
    public int? SupplierID { get; set; }
    public Supplier Supplier { get; set; } = new Supplier();
    public int? WarehouseID { get; set; }
    public Warehouse? Warehouse { get; set; }   
    public string? Status { get; set; }
    public int? CurrencyID { get; set; }
    public InventoryCurrency? Currency { get; set; } 
    public string? Total { get; set; }
}
