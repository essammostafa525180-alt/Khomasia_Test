namespace Infrastructure.Models.LookupTables;

/// <summary>Score Scale</summary>
public class ScoreScale
{
    public int Id { get; set; }  // PK
    public string? Code { get; set; }
    public string? NameAr { get; set; }
    public string? NameEn { get; set; }
    public decimal? Minscore { get; set; }
    public decimal? Maxscore { get; set; }
    public short Precision { get; set; }

}
