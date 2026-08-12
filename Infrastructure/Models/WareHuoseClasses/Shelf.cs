namespace Infrastructure.Models.WareHuoseClasses
{
    public class Shelf
    {
        public int Id { get; set; }

        public int IsleId { get; set; }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public int Level { get; set; }

        public decimal? MaxWeight { get; set; }

        public bool IsActive { get; set; } = true;


        // Navigation

        public Isle Isle { get; set; } = null!;

        public ICollection<Rack> Racks { get; set; }
            = new List<Rack>();
    }




}
