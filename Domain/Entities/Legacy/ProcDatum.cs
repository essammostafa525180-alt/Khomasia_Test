namespace Domain.Entities.Legacy;

public class ProcDatum
{
    public long Id { get; set; }
    public string? Description { get; set; }
    public string? Query { get; set; }
    public bool IsRun { get; set; }
}
