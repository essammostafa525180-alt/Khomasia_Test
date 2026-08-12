namespace Infrastructure.Models.WareHuoseClasses
{
    public class StorageUnit
    {
        public int Id { get; set; }

        public int WarehouseId { get; set; }

        public StorageUnitType Type { get; set; }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal? Capacity { get; set; }

        public string? CapacityUnit { get; set; }

        public bool IsActive { get; set; } = true;


        // Navigation

        public Warehouse Warehouse { get; set; } = null!;

        public ICollection<Isle> Isles { get; set; }
            = new List<Isle>();
    }




}
