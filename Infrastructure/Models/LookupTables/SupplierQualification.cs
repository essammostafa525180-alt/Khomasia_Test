using Domain.Aggregates.UserAggregate;

namespace Infrastructure.Models.LookupTables;

/// <summary>Supplier Qualification</summary>
public class SupplierQualification
{
    public int Id { get; set; }  // PK
    public int QualificationTypeID { get; set; }
    public int CategoryID { get; set; }
    public int SupplierID { get; set; }
    public Supplier? Supplier { get; set; }  // Navigation property to Supplier
    public int StatusID { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public decimal? Score { get; set; }
    public int? ApprovedBy { get; set; }  // FK -> Employee
    public Employee? ApprovedByEmployee { get; set; }

}



    


   