using Domain.Aggregates.InventoryItemAggregate;

namespace Infrastructure.Models.LookupTables;

public class QualityInspection
{
    /// <summary>
    /// فحص الجودة 
    /// </summary>
    public int Id { get; set; }  // PK
    public string? InspectionNo { get; set; }
    public int GRNID { get; set; }
    public GoodsReceipt? Grn { get; set; }    
    public int ItemID { get; set; }
    public InventoryItem? Item { get; set; } = null;
    public string? Result { get; set; }
    public string? Disposition { get; set; }
    public string? Status { get; set; }
}
