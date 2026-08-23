using Infrastructure.Models.LookupTables;

public class Budget
{
    public int ID { get; set; }  // PK
    public string? BudgetCode { get; set; }
    public string? FiscalYear { get; set; }
    public int? CostCenterID { get; set; }  // FK -> CostCenter
    public CostCenter? CostCenter { get; set; }
    public int? ProjectID { get; set; }  // FK -> Project
    public Project? Project { get; set; }
    public int? AccountID { get; set; }  // FK -> GlAccount
    public GlAccount? Account { get; set; }
    public decimal? Amount { get; set; }
}