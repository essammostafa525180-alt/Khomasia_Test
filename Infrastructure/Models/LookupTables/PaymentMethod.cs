namespace Infrastructure.Models.LookupTables;

public class PaymentMethod
{
    public int Id { get; set; }  // PK
    public string? Code { get; set; }
    public string? Name { get; set; }
}
