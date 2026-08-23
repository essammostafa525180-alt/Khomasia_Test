namespace Infrastructure.Models.LookupTables;

public class Department
    {
        public int Id { get; set; }  // PK
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Manager { get; set; }
        public int? ParentDepartmentID { get; set; }  // FK -> Department
        public Department? ParentDepartment { get; set; }
    }
