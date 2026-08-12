using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Employee
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

    public long? EmployeeJobFk { get; set; }

    public virtual ICollection<AssetItemMove> AssetItemMoveEmployeeFkNavigations { get; set; } = new List<AssetItemMove>();

    public virtual ICollection<AssetItemMove> AssetItemMoveManagerApprovedFkNavigations { get; set; } = new List<AssetItemMove>();

    public virtual ICollection<AssetItemMove> AssetItemMoveOwnerApprovedFkNavigations { get; set; } = new List<AssetItemMove>();

    public virtual ICollection<AssetItem> AssetItems { get; set; } = new List<AssetItem>();

    public virtual EmployeeJob? EmployeeJobFkNavigation { get; set; }

    public virtual ICollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdraws { get; set; } = new List<InventroyItemRequestWithdraw>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
