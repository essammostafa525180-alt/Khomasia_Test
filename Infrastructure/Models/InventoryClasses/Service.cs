using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Service
{
    public long Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[]? RowVersion { get; set; }

    public long? ServiceTypeFk { get; set; }

    public long? ServiceMainCategoryFk { get; set; }

    public long? ServiceCategoryFk { get; set; }

    public long? ServiceSubCategoryFk { get; set; }

    public virtual ICollection<PoserviceDetail> PoserviceDetails { get; set; } = new List<PoserviceDetail>();

    public virtual ServiceCategory? ServiceCategoryFkNavigation { get; set; }

    public virtual ServiceMainCategory? ServiceMainCategoryFkNavigation { get; set; }

    public virtual ServiceSubCategory? ServiceSubCategoryFkNavigation { get; set; }
}
