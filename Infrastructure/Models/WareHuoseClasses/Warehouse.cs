namespace Infrastructure.Models.WareHuoseClasses
{
    public class Warehouse
    {
        public int Id { get; set; }

        public int WarehouseTypeId { get; set; }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? Address { get; set; }

        public bool IsActive { get; set; } = true;


        // Navigation

        public WarehouseType WarehouseType { get; set; } = null!;

        public ICollection<StorageUnit> StorageUnits { get; set; }
            = new List<StorageUnit>();
    }




}
