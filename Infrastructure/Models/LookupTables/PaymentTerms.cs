namespace Infrastructure.Models.LookupTables;

public class PaymentTerms
{
    public int Id { get; set; }  // PK
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Days { get; set; }
    public string? DiscountTerms { get; set; }
}
