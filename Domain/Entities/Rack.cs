using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Rack : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public int? IsleFk { get; private set; }
        public Isle? IsleFkNavigation { get; private set; }

        private List<Shelf> _shelves = new List<Shelf>();
        public IReadOnlyCollection<Shelf> Shelves => _shelves;

        private Rack()
        {
        }

        public Rack(string? name, string? nameAr, int? isleFk, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsleFk = isleFk;
            IsActive = isActive;
        }

        public static Rack Create(string? name, string? nameAr, int? isleFk, bool isActive)
        {

            return new Rack(name, nameAr, isleFk, isActive);
        }

        public void Update(string? name, string? nameAr, int? isleFk, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsleFk = isleFk;
            IsActive = isActive;
        }
    }
}
