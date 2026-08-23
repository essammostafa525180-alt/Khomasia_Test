namespace Infrastructure.Models.LookupTables;

/// <summary>Manufacturer</summary>
public class Manufacturer
{
    public int Id { get; set; }  // PK
    public string? ManufactureEn { get; set; }
    public string? ManufactureAr { get; set; }
}
