namespace Domain.Entities.Legacy;

public class Cairo2024
{
    public string? Store { get; set; }
    public string? ItemName { get; set; }
    public double? Quantity { get; set; }
    public string? MaterialGroup { get; set; }
    public string? MaterialCategory { get; set; }
    public string? MaterialSubCategory { get; set; }
    public string? UnitOfMeasure { get; set; }
    public long? InventoryItemFk { get; set; }
    public long? StoreFk { get; set; }
}
