namespace Infrastructure.Models.LookupTables;

/// <summary>Commercial Evaluation Criterion</summary>
public class CommercialEvaluationCriterion
{
    public int Id { get; set; }  // PK
    public string? Code { get; set; }
    public string? NameAr { get; set; }
    public string? NameEn { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Maxscore { get; set; }

}
