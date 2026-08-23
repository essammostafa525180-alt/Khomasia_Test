
using Domain.Entities;

namespace Infrastructure.Models.LookupTables;

/// <summary>Supplier Bank Account</summary>
public class SupplierBankAccount
{
    public int Id{ get; set; }  // PK

    public int? SupplierID { get; set; }
    public Supplier? Supplier { get; set; }
    public int? BankID { get; set; }
    public string? AccountName { get; set; }
    public string? Iban { get; set; }
    public string? Swift { get; set; }
    public int? CurrencyID { get; set; }
    public InventoryCurrency? Currency { get; set; }

    public bool Verified { get; set; }
    public DateOnly? EffectiveFrom { get; set; }
    public DateOnly? EffectiveTo { get; set; }
}
