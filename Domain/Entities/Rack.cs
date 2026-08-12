using Domain.Primitives;

namespace Domain.Entities
{
    public class Rack : AuditableEntityBase<int>
    {
        public int ShelfFk { get; private set; }
        public Shelf? ShelfFkNavigation { get; private set; }
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public decimal? Capacity { get; private set; }
        public decimal? MaxWeight { get; private set; }

        private Rack() { }

        public Rack(int shelfFk, string? code, string? name, decimal? capacity, decimal? maxWeight, bool isActive) : this()
        {
            ShelfFk = shelfFk;
            Code = code;
            Name = name;
            Capacity = capacity;
            MaxWeight = maxWeight;
            IsActive = isActive;
        }

        public static Rack Create(int shelfFk, string? code, string? name, decimal? capacity, decimal? maxWeight, bool isActive)
        {
            return new Rack(shelfFk, code, name, capacity, maxWeight, isActive);
        }

        public void Update(int shelfFk, string? code, string? name, decimal? capacity, decimal? maxWeight, bool isActive)
        {
            ShelfFk = shelfFk;
            Code = code;
            Name = name;
            Capacity = capacity;
            MaxWeight = maxWeight;
            IsActive = isActive;
        }
    }
}
