namespace Infrastructure.Models.WareHuoseClasses
{
    public class Rack
    {
        public int Id { get; set; }

        public int ShelfId { get; set; }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public decimal? Capacity { get; set; }

        public decimal? MaxWeight { get; set; }

        public bool IsActive { get; set; } = true;


        // Navigation

        public Shelf Shelf { get; set; } = null!;
    }




}
