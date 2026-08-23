using Domain.Entities;

namespace Infrastructure.Models.LookupTables;

public class TaxCode
{
    public int Id { get; set; }  // PK

    public string? Code { get; set; } // renamed from TaxCode to avoid name/type    
    public string? Name { get; set; }
    public string? NameAr { get; set; }
    public string? Rate { get; set; }
    public string? Type { get; set; }
    public int? CountryID { get; set; } 
    public Country? Country { get; set; }
    public DateOnly? EffectiveFrom { get; set; }
    public DateOnly? EffectiveTo { get; set; }
}
