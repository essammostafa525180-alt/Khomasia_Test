using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Company
{
    public long Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<AllowedCompany> AllowedCompanies { get; set; } = new List<AllowedCompany>();

    public virtual ICollection<ApprovalMatrixConfig> ApprovalMatrixConfigs { get; set; } = new List<ApprovalMatrixConfig>();

    public virtual ICollection<InventoryItemBudget> InventoryItemBudgets { get; set; } = new List<InventoryItemBudget>();

    public virtual ICollection<InventoryItemCost> InventoryItemCosts { get; set; } = new List<InventoryItemCost>();

    public virtual ICollection<InventoryTransfere> InventoryTransfereCompanyFromFkNavigations { get; set; } = new List<InventoryTransfere>();

    public virtual ICollection<InventoryTransfere> InventoryTransfereCompanyToFkNavigations { get; set; } = new List<InventoryTransfere>();

    public virtual ICollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdraws { get; set; } = new List<InventroyItemRequestWithdraw>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<PurchaseOrderService> PurchaseOrderServices { get; set; } = new List<PurchaseOrderService>();

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();

    public virtual ICollection<VendorOrder> VendorOrders { get; set; } = new List<VendorOrder>();
}
