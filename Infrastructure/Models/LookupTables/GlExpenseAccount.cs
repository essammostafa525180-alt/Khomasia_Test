
public class GlExpenseAccount
{
    public long AccountID { get; set; }  // PK
    public string? AccountCode { get; set; }
    public string ?Name { get; set; }
    public string? Type { get; set; }
    public int? CompanyID { get; set; }
    public Domain.Aggregates.CompanyAggregate.Company? Company { get; set; } = null;
}
