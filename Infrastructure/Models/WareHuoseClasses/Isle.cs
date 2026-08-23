namespace Infrastructure.Models.WareHuoseClasses
{
    public class Isle
    {
        public int Id { get; set; }

        public int StorageUnitId { get; set; }
        public int ZoneID { get; set; }  // FK -> WarehouseZone

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public int Sequence { get; set; }

        // Navigation

        public StorageUnit StorageUnit { get; set; } = null!;
        public WarehouseZone Zone { get; set; }
        public ICollection<Shelf> Shelves { get; set; }
            = new List<Shelf>();
    }




}
