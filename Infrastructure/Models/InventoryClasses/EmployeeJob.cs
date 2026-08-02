using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class EmployeeJob
{
    public long Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public long? EmployeeJobFk { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<PoserviceOutsource> PoserviceOutsources { get; set; } = new List<PoserviceOutsource>();

    public virtual ICollection<PoserviceRecomendedResource> PoserviceRecomendedResources { get; set; } = new List<PoserviceRecomendedResource>();
}
