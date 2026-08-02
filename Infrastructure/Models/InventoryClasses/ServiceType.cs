using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class ServiceType
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

    public virtual ICollection<PoserviceDetail> PoserviceDetails { get; set; } = new List<PoserviceDetail>();

    public virtual ICollection<ServiceCategory> ServiceCategories { get; set; } = new List<ServiceCategory>();

    public virtual ICollection<ServiceSubCategory> ServiceSubCategories { get; set; } = new List<ServiceSubCategory>();
}
