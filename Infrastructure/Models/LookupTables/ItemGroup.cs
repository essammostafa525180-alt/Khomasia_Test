namespace Infrastructure.Models.LookupTables;

public class ItemGroup
{
    public int Id { get; set; }  
    public string? GroupCode { get; set; }
    public string? ShortName { get; set; }
    public string? MaterialGroupEn { get; set; }
    public string? MaterialGroupAr { get; set; }
    public int? ParentGroupID { get; set; }  
    public ItemGroup? ParentGroup { get; set; }
}
