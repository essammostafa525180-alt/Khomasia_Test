using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class PoserviceDetail
{
    public long Id { get; set; }

    public long? PoserviceFk { get; set; }

    public long? ServiceTypeFk { get; set; }

    public long? ServiceMainCategoryFk { get; set; }

    public long? ServiceCategoryFk { get; set; }

    public long? ServiceSubCategoryFk { get; set; }

    public long? ServiceFk { get; set; }

    public int? Quantity { get; set; }

    public decimal? CostPerService { get; set; }

    public decimal? TotalCost { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public long? ContractServiceId { get; set; }

    public virtual PurchaseOrderService? PoserviceFkNavigation { get; set; }

    public virtual ServiceCategory? ServiceCategoryFkNavigation { get; set; }

    public virtual Service? ServiceFkNavigation { get; set; }

    public virtual ServiceMainCategory? ServiceMainCategoryFkNavigation { get; set; }

    public virtual ServiceSubCategory? ServiceSubCategoryFkNavigation { get; set; }

    public virtual ServiceType? ServiceTypeFkNavigation { get; set; }
}
