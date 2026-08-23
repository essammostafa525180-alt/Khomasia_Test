namespace Infrastructure.Models.LookupTables;

/// <summary>Purchase Requisition</summary>
public class PurchaseRequisition
{
    public int Id { get; set; }  // PK
    public string? PurchaseRequestNo { get; set; }
    public bool? Status { get; set; }
    public int? RequesterEmployeeID { get; set; }
    public Employee? Employee { get; set; }  
    public int? DepartmentID { get; set; }
    public Department? Department { get; set; }
    public DateOnly? Date { get; set; }
}
