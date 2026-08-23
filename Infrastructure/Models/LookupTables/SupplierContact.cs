namespace Infrastructure.Models.LookupTables;

/// <summary>Supplier Contact</summary>
public class SupplierContact
{
    public int? SupplierID { get; set; }  // FK -> Supplier
    public Supplier? Supplier { get; set; }
    public string? Name { get; set; }
    public string? Role { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public bool? Primary { get; set; }
}
