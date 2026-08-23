using Domain.Aggregates.InventoryItemAggregate;
using Domain.Entities;

namespace Infrastructure.Models.LookupTables;

/// <summary>Supplier Item</summary>
public class SupplierItem
{
    public int Id { get; set; }  // PK
    public int SupplierID { get; set; }
    public Supplier? Supplier { get; set; }  // Navigation property to Supplier
    public int? ItemID { get; set; }
    public InventoryItem? Item { get; set; }  // Navigation property to Item  
    public string? Supplieritemcode { get; set; }
    public int? UOMID { get; set; }
    public UnitOfMeasure? UOM { get; set; }  // Navigation property to UOM
    public decimal? Moq { get; set; }
    public int Leadtime { get; set; }
    public decimal? Price { get; set; }
    public int? CurrencyID { get; set; }
    public InventoryCurrency? Currency { get; set; }  // Navigation property to Currency     
    public string? Validity { get; set; }

}
