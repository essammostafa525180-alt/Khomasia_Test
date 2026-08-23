using Infrastructure.Models.WareHuoseClasses;

namespace Infrastructure.Models.LookupTables;

public class GoodsReceipt
{
    public int Id { get; set; }  // PK
    public string? GrnNo { get; set; }
    public int POID { get; set; }
    public PurchaseOrder? PurchaseOrder { get; set; } = null;
    public int? WarehouseID { get; set; }
    public Warehouse? Warehouse { get; set; } = null;
    public DateOnly? Date { get; set; }
    public bool? Status { get; set; }
}
