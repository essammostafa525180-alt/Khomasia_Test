using Domain.Entities;

namespace Infrastructure.Models.LookupTables;

public class Bank
{
    public int Id { get; set; }  // PK
    public string? BankCode { get; set; }
    public string? Name { get; set; }
    public string? NameAr { get; set; }
    public int? CountryID { get; set; }
    public Country? Country { get; set; }
    public string? SwiftBic { get; set; }
}

