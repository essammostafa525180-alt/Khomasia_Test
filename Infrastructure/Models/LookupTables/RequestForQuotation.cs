namespace Infrastructure.Models.LookupTables;

public class RequestForQuotation
{
    public int Id { get; set; }  // PK
    public string? RequestForQuotationNo { get; set; }
    public string? Status { get; set; }
    public int? BuyerGroupID { get; set; } // Refer to  ????
    public DateOnly? Date { get; set; }
}
