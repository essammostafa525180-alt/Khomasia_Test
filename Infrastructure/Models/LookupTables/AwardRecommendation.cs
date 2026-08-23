namespace Infrastructure.Models.LookupTables;

public class AwardRecommendation 
{
    /// <summary>
    /// مش عارف معناه ايه 
    /// </summary>
    public int Id { get; set; }  // PK
    public string? AwardNo { get; set; }
    public int SupplierID { get; set; }
    public Supplier? Supplier { get; set; }
    public int RequestForQuotationID { get; set; }
    public RequestForQuotation? RequestForQuotation { get; set; }
    public string? Decision { get; set; }
    public string? Status { get; set; }
}
