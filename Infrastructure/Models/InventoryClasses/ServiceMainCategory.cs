using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class ServiceMainCategory
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

    public long? FinanceCostCenterId { get; set; }

    public virtual ICollection<ApprovalMatrixConfig> ApprovalMatrixConfigs { get; set; } = new List<ApprovalMatrixConfig>();

    public virtual ICollection<InventoryItemBudget> InventoryItemBudgets { get; set; } = new List<InventoryItemBudget>();

    public virtual ICollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdraws { get; set; } = new List<InventroyItemRequestWithdraw>();

    public virtual ICollection<PoserviceDetail> PoserviceDetails { get; set; } = new List<PoserviceDetail>();

    public virtual ICollection<PurchaseOrderService> PurchaseOrderServices { get; set; } = new List<PurchaseOrderService>();

    public virtual ICollection<ServiceCategory> ServiceCategories { get; set; } = new List<ServiceCategory>();

    public virtual ICollection<ServiceSubCategory> ServiceSubCategories { get; set; } = new List<ServiceSubCategory>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual ICollection<VendorOrder> VendorOrders { get; set; } = new List<VendorOrder>();
}
