namespace Infrastructure.Models.LookupTables;

public class Vehicle
{
    public int Id { get; set; }  // PK
    public string? VehicleCode { get; set; }
    public string? PlateNo { get; set; }
    public string? Type { get; set; }
    public string? Capacity { get; set; }
    public int? DriverID { get; set; }
    public Driver Driver { get; set; }  // Navigation property to Driver

}
