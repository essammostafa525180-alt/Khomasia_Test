namespace Infrastructure.Models.LookupTables;

/// <summary>Supplier Return</summary>
public class SupplierReturn
{
    public int ReturnID { get; set; }  // PK

    public string ReturnNo { get; set; }
    public int SupplierID { get; set; }
    public int GRNID { get; set; }
    public string Reason { get; set; }
    public string Status { get; set; }
}
