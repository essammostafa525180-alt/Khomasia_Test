using Domain.Aggregates.StoreAggregate;
using Domain.Aggregates.VendorOrderAggregate;
using Infrastructure.Models.LookupTables;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class User
{
    public long Id { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? UserId { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public long? Contact { get; set; }

    public bool? Active { get; set; }

    public long? Ouid { get; set; }

    public string? NameAr { get; set; }

    public long? BranchId { get; set; }

    public DateTime? LastLogin { get; set; }

    public bool? ForcePasswordChange { get; set; }

    public long? EmployeeId { get; set; }

    public long? MaxDiscount { get; set; }

    public DateTime? PasswordCreationDate { get; set; }

    public string? FullName { get; set; }

    public byte[]? ProfilePicture { get; set; }

    public long? AdUserId { get; set; }

    public bool? IsPda { get; set; }

    public int? SingleSession { get; set; }

    public byte[] Timestamp { get; set; } = null!;

    public virtual AdUser? AdUser { get; set; }

    public virtual ICollection<ApprovalMatrixConfigDetail> ApprovalMatrixConfigDetails { get; set; } = new List<ApprovalMatrixConfigDetail>();

    public virtual ICollection<ApprovalMatrixDetail> ApprovalMatrixDetails { get; set; } = new List<ApprovalMatrixDetail>();

    public virtual ICollection<AuditTrail> AuditTrails { get; set; } = new List<AuditTrail>();

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<InventoryItemReturn> InventoryItemReturnCreatedByNavigations { get; set; } = new List<InventoryItemReturn>();

    public virtual ICollection<InventoryItemReturn> InventoryItemReturnLastUpdatedByNavigations { get; set; } = new List<InventoryItemReturn>();

    public virtual ICollection<InventoryItemReturn> InventoryItemReturnReturnedByFkNavigations { get; set; } = new List<InventoryItemReturn>();

    public virtual ICollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdrawAssignedToUserFkNavigations { get; set; } = new List<InventroyItemRequestWithdraw>();

    public virtual ICollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdrawCreatedByNavigations { get; set; } = new List<InventroyItemRequestWithdraw>();

    public virtual ICollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdrawLastUpdatedByNavigations { get; set; } = new List<InventroyItemRequestWithdraw>();

    public virtual ICollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdrawRequestedByFkNavigations { get; set; } = new List<InventroyItemRequestWithdraw>();

    public virtual Ou? Ou { get; set; }

    public virtual ICollection<Pruser> Prusers { get; set; } = new List<Pruser>();

    public virtual ICollection<SalesInvoice> SalesInvoices { get; set; } = new List<SalesInvoice>();

    public virtual ICollection<SecUserModelAtrribute> SecUserModelAtrributes { get; set; } = new List<SecUserModelAtrribute>();

    public virtual ICollection<SecUserModule> SecUserModules { get; set; } = new List<SecUserModule>();

    public virtual ICollection<SecUserProperty> SecUserProperties { get; set; } = new List<SecUserProperty>();

    public virtual ICollection<SecUserViewAction> SecUserViewActions { get; set; } = new List<SecUserViewAction>();

    public virtual ICollection<StoreKeeper> StoreKeepers { get; set; } = new List<StoreKeeper>();

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();

    public virtual ICollection<UserSessionInfo> UserSessionInfos { get; set; } = new List<UserSessionInfo>();

    public virtual ICollection<VendorOrder> VendorOrderAssignedToUserFkNavigations { get; set; } = new List<VendorOrder>();

    public virtual ICollection<VendorOrder> VendorOrderCreatedByNavigations { get; set; } = new List<VendorOrder>();

    public virtual ICollection<VendorOrder> VendorOrderLastUpdatedByNavigations { get; set; } = new List<VendorOrder>();

    public virtual ICollection<VendorOrder> VendorOrderOrderByUserFkNavigations { get; set; } = new List<VendorOrder>();

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();

    public virtual ICollection<SecRole> Roles { get; set; } = new List<SecRole>();
}
