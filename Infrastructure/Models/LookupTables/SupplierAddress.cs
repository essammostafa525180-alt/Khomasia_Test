using Domain.Entities;
using MimeKit;

namespace Infrastructure.Models.LookupTables;

/// <summary>Supplier Address</summary>
public class SupplierAddress
{
    public int Id { get; set; }  // PK
    public int? SupplierID { get; set; }
    public Supplier Supplier { get; set; }

    public string? AddressType { get; set; }
    public int? CountryID { get; set; }
    public Country? Country { get; set; }

    public int? CityID { get; set; }
    public City? City { get; set; }

    public string? Address { get; set; }
    public bool? Primary { get; set; }
}
