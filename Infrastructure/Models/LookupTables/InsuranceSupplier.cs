namespace Infrastructure.Models.LookupTables;

/// <summary>Insurance Supplier</summary>
public class InsuranceSupplier
{
    public int Id { get; set; }  // PK
    public string? InsuranceSupplierEn { get; set; }
    public string? InsuranceSupplierAr { get; set; }
}
