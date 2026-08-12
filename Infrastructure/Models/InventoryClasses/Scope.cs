using Domain.Aggregates.VendorOrderAggregate;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Scope
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

    public virtual ICollection<ApprovalMatrixConfig> ApprovalMatrixConfigs { get; set; } = new List<ApprovalMatrixConfig>();

    public virtual ICollection<InventoryItemBudget> InventoryItemBudgets { get; set; } = new List<InventoryItemBudget>();

    public virtual ICollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdraws { get; set; } = new List<InventroyItemRequestWithdraw>();

    public virtual ICollection<PurchaseOrderService> PurchaseOrderServices { get; set; } = new List<PurchaseOrderService>();

    public virtual ICollection<VendorOrder> VendorOrders { get; set; } = new List<VendorOrder>();
}
