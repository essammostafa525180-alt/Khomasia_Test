using Domain.Entities;
using System;
using System.Collections.Generic;
using Domain.Aggregates.InventoryStockCountAggregate;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryStockCountPlan
{
    public long Id { get; set; }

    public string? CountPlanNo { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public DateTime? PlanDate { get; set; }

    public DateTime? ExecutionDate { get; set; }

    public long? StockCountPlanStatusFk { get; set; }

    public long? StockCountPlanTypeFk { get; set; }

    public long? AssignedToUserFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<InventoryStockCountPlanDetail> InventoryStockCountPlanDetails { get; set; } = new List<InventoryStockCountPlanDetail>();

    public virtual StockCountPlanStatus? StockCountPlanStatusFkNavigation { get; set; }

    public virtual StockCountPlanType? StockCountPlanTypeFkNavigation { get; set; }
}
