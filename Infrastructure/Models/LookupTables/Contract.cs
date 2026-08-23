namespace Infrastructure.Models.LookupTables;

public class Contract
{
    public int Id { get; set; }  // PK
    public string? ContractNo { get; set; }
    public int? SupplierID { get; set; }
    public Supplier? Supplier { get; set; }  
    public string? Type { get; set; }
    public string? Status { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}
