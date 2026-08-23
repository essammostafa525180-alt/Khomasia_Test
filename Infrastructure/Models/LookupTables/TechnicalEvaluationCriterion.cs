namespace Infrastructure.Models.LookupTables;

/// <summary>Technical Evaluation Criterion</summary>
public class TechnicalEvaluationCriterion
{
    public int Id { get; set; }  // PK
    public string? Code { get; set; }
    public string? Name { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Maxscore { get; set; }
    public decimal? Passingscore { get; set; }

}
