using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Isle : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<Rack> _racks = new List<Rack>();
        public IReadOnlyCollection<Rack> Racks => _racks;

        private Isle()
        {
        }

        public Isle(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static Isle Create(string? name, string? nameAr, bool isActive)
        {

            return new Isle(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
