using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.Models.LookupTables;
public class InspectionCriterion
{
    public int Id { get; set; }  // PK
    public int? SpecID { get; set; }
    public VendorSpecialization? Spec { get; set; }  // Navigation property to ?????
    public string? Code { get; set; }
    public string? NameAr { get; set; }
    public string? NameEn { get; set; }
    public int? MeasurementTypeID { get; set; }
    public MeasurementType? MeasurementType { get; set; }  // Navigation property to MeasurementType
    public decimal? Limitmin { get; set; }
    public decimal? Limitmax { get; set; }
    public int? UOMID { get; set; }
    public UnitOfMeasure? UnitOfMeasure { get; set; }  // Navigation property to UOM
    public bool Mandatory { get; set; }
}
