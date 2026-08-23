namespace Infrastructure.Models.LookupTables;

/// <summary>Carrier</summary>
public class Carrier
{
    public int Id { get; set; }  // PK
    public string? CarrierCode { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Contact { get; set; }
    public string? Phone { get; set; }

}
