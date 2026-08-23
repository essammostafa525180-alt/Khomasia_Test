using Domain.Aggregates.InventoryItemAggregate;

namespace Infrastructure.Models.LookupTables;

/// <summary>Inspection Specification</summary>
public class InspectionSpecification
{
    public int Id { get; set; }  // PK

    public string? Code { get; set; }
    public string? Name { get; set; }
    public int? ItemID { get; set; }
    public InventoryItem? Item { get; set; } = null;
    public string? Version { get; set; }
    public DateOnly? EffectiveFrom { get; set; }
    public DateOnly? EffectiveTo { get; set; }

}
