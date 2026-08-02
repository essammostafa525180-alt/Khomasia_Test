using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class PoserviceAsset
{
    public long Id { get; set; }

    public long PoserviceFk { get; set; }

    public long ContractServiceId { get; set; }

    public int IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public long ContractAssetId { get; set; }

    public long AssetId { get; set; }

    public string? AssetCode { get; set; }

    public string? AssetDescription { get; set; }

    public string? AssetDescriptionAr { get; set; }

    public virtual PurchaseOrderService PoserviceFkNavigation { get; set; } = null!;
}
