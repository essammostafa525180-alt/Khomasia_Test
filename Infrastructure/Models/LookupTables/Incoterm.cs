namespace Infrastructure.Models.LookupTables;

/// <summary>Incoterm</summary>
public class Incoterm
{
    public int Id { get; set; }  // PK
    public string? Code { get; set; }
    public string? Version { get; set; }
    public string? DescriptionAr { get; set; } = null;
    public string? DescriptionEn { get; set; } = null;
}
