namespace Infrastructure.Models.LookupTables;

/// <summary>Supplier Compliance Document</summary>
public class SupplierComplianceDocument
{
    public int Id { get; set; }  // PK

    public int SupplierID { get; set; }
    public Supplier? Supplier { get; set; }  // Navigation property to Supplier
    public int DocumentTypeID { get; set; }
    public string? Number { get; set; }
    public DateOnly? IssueDate { get; set; }
    public DateOnly? ExpiryDate { get; set; }
    public int StatusID { get; set; }
    public int AttachmentID { get; set; }
}
