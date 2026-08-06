namespace Domain.Entities.Legacy;

public class InventoryItemLocationDetail20240723
{
    public long Id { get; set; }
    public DateTime? CreatedOn { get; set; }
    public DateTime? LastUpdatedOn { get; set; }
    public long? CreatedBy { get; set; }
    public long? LastUpdatedBy { get; set; }
    public bool IsActive { get; set; }
    public byte[] RowVersion { get; set; }
    public long? StoreFk { get; set; }
    public long? InventoryItemFk { get; set; }
    public long? ItemQuantityTypeFk { get; set; }
    public long? TransactionTypeFk { get; set; }
    public string? Screen { get; set; }
    public long? EntityId { get; set; }
    public string? EntityCode { get; set; }
    public DateTime? EntityDate { get; set; }
    public long? EntityDetailId { get; set; }
    public long? InventoryItemLocationFk { get; set; }
    public decimal? QuantityBefore { get; set; }
    public decimal Quantity { get; set; }
    public decimal? QuantityAfter { get; set; }
    public decimal? EntityDetailCost { get; set; }
    public double? Avgcost { get; set; }
}
