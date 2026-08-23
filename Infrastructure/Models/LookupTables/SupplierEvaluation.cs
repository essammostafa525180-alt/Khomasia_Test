using Domain.Enums;

namespace Infrastructure.Models.LookupTables;

/// <summary>Supplier Evaluation</summary>
public class SupplierEvaluation
{
    public int Id { get; set; }  // PK
    public int SupplierID { get; set; }
    public Supplier? Supplier { get; set; }  // Navigation property to Supplier
    public string? Period { get; set; }
    public int EvaluationTypeID { get; set; }
    public EvaluationFrequency EvaluationFrequency { get; set; } = new EvaluationFrequency();
    public decimal? Score { get; set; }
    public int RatingID { get; set; }
    public int StatusID { get; set; }
    public int? EvaluatorEmployeeID { get; set; }
    public Employee? EvaluatorEmployee { get; set; }  // Navigation property to Employee
}
