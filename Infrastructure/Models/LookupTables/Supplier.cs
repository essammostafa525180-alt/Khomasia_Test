using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.Models.LookupTables;

/// <summary>Supplier</summary>
public class Supplier
{
    public int Id { get; set; }  // PK
    public string? SupplierCode { get; set; }
    public string? NameEn { get; set; }
    public string? NameAr { get; set; }
    public string? TaxRegNo { get; set; }
    public string? CommercialRegNo { get; set; }
    public int? SupplierTypeID { get; set; }
    public SupplierType? SupplierType { get; set; }
    public int? SupplierCategoryID { get; set; }
    public SupplierCategory? SupplierCategory { get; set; }
    public int? StatusID { get; set; }
    public int CountryID { get; set; }
    public Country? Country { get; set; }
    public int StateID { get; set; }
    public State? State { get; set; }
    public int CityID { get; set; }
    public City? City { get; set; } = null;
    public int DefaultPaymentTermID { get; set; }
    public PaymentTerm? PaymentTerm { get; set; } = null;
    public int DefaultCurrencyID { get; set; }
    public InventoryCurrency? InventoryCurrency { get; set; } = null;
    public string? ContactPerson { get; set; }
    public string? Phone1 { get; set; }
    public string? Phone2 { get; set; }
    public string? Fax { get; set; }
    public string? Email { get; set; }
    public string? BankAccountNumber { get; set; }
    public string? Website { get; set; }
    public string? Remark { get; set; }
    public string? Reference { get; set; }
    public string? Address { get; set; }
    public bool? IsApproved { get; set; }
}
