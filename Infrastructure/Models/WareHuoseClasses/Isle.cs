namespace Infrastructure.Models.WareHuoseClasses
{
    public class Isle
    {
        public int Id { get; set; }

        public int StorageUnitId { get; set; }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public int Sequence { get; set; }

        public bool IsActive { get; set; } = true;


        // Navigation

        public StorageUnit StorageUnit { get; set; } = null!;

        public ICollection<Shelf> Shelves { get; set; }
            = new List<Shelf>();
    }




}
