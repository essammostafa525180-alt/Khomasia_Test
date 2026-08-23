namespace Infrastructure.Models.WareHuoseClasses;

public class WarehouseZone
{
    public int ID { get; set; }  
    public string ZoneCode { get; set; }
    public string Name { get; set; }
    public string ZoneType { get; set; }
    public string StorageClass { get; set; }
    public bool IsActive { get; set; }
    public int WarehouseID { get; set; }  // FK -> Warehouse
    public Warehouse Warehouse { get; set; }
}

