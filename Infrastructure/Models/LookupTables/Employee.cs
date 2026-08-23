using Infrastructure.Models.InventoryClasses;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models.LookupTables;

public  class Employee
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? NameAr { get; set; }
    public string? NameEn { get; set; }
    public string? JobTitle { get; set; }
    public string? Email { get; set; }
    public int? DepartmentID { get; set; }
    public Department? department { get; set; }
    public int? UserID { get; set; }
    public User? user { get; set; }

}
