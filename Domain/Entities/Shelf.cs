using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Shelf : AuditableEntityBase<int>
    {
        public int IsleFk { get; private set; }
        public Isle? IsleFkNavigation { get; private set; }
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public int Level { get; private set; }
        public decimal? MaxWeight { get; private set; }

        private List<Rack> _racks = new List<Rack>();
        public IReadOnlyCollection<Rack> Racks => _racks;

        private Shelf() { }

        public Shelf(int isleFk, string? code, string? name, int level, decimal? maxWeight, bool isActive) : this()
        {
            IsleFk = isleFk;
            Code = code;
            Name = name;
            Level = level;
            MaxWeight = maxWeight;
            IsActive = isActive;
        }

        public static Shelf Create(int isleFk, string? code, string? name, int level, decimal? maxWeight, bool isActive)
        {
            return new Shelf(isleFk, code, name, level, maxWeight, isActive);
        }

        public void Update(int isleFk, string? code, string? name, int level, decimal? maxWeight, bool isActive)
        {
            IsleFk = isleFk;
            Code = code;
            Name = name;
            Level = level;
            MaxWeight = maxWeight;
            IsActive = isActive;
        }
    }
}
