namespace Infrastructure.Models.LookupTables;

public class Sla
{
    public int Id { get; set; }  // PK
    public string? Code { get; set; }
    public string? Name { get; set; }
    public int CategoryID { get; set; }
    //public SlaCategory Category { get; set; } ???? // Navigation property to SlaCategory
    public string? Responsetime { get; set; }
    public string? Resolutiontime { get; set; }
    public string? Unit { get; set; }

}
