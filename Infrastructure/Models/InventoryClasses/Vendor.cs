using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Vendor
{
    public long Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public long? CityFk { get; set; }

    public long? VendorStatusFk { get; set; }

    public string? ContactPerson { get; set; }

    public string? Phone1 { get; set; }

    public string? Phone2 { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public string? Website { get; set; }

    public string? Address { get; set; }

    public string? Remark { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public string? Reference { get; set; }

    public string? CommercialRegistration { get; set; }

    public string? BankAccountNumber { get; set; }

    public string? TaxRegistration { get; set; }

    public bool? IsApproved { get; set; }

    public string? PaymentTerms { get; set; }

    public long? VendorTypeFk { get; set; }

    public long? FinanceId { get; set; }

    public virtual ICollection<AssignVendorEvaluationCriterion> AssignVendorEvaluationCriteria { get; set; } = new List<AssignVendorEvaluationCriterion>();

    public virtual ICollection<AssignVendorSpecialization> AssignVendorSpecializations { get; set; } = new List<AssignVendorSpecialization>();

    public virtual City? CityFkNavigation { get; set; }

    public virtual ICollection<InventoryItemVendor> InventoryItemVendors { get; set; } = new List<InventoryItemVendor>();

    public virtual ICollection<PoserviceRecomendedResource> PoserviceRecomendedResources { get; set; } = new List<PoserviceRecomendedResource>();

    public virtual ICollection<PurchaseOrderService> PurchaseOrderServices { get; set; } = new List<PurchaseOrderService>();

    public virtual ICollection<VendorAttachment> VendorAttachments { get; set; } = new List<VendorAttachment>();

    public virtual ICollection<VendorOrderVendorSelection> VendorOrderVendorSelections { get; set; } = new List<VendorOrderVendorSelection>();

    public virtual ICollection<VendorOrder> VendorOrders { get; set; } = new List<VendorOrder>();

    public virtual VendorStatus? VendorStatusFkNavigation { get; set; }

    public virtual VendorType? VendorTypeFkNavigation { get; set; }
}
