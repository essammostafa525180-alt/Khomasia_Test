namespace Infrastructure.Models.LookupTables;

/// <summary>Supplier Category</summary>
public class SupplierCategory
{
    public int Id { get; set; }  // PK
    public string? Code { get; set; }
    public string? Name { get; set; }
    public int? ParentCategoryID { get; set; }
    public SupplierCategory? ParentCategory { get; set; }
}
