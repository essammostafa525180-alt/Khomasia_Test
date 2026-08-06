using Domain.Aggregates.ZoneAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ZoneStatus : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<Zone> _zones = new List<Zone>();
        public IReadOnlyCollection<Zone> Zones => _zones;

        private ZoneStatus()
        {
        }

        public ZoneStatus(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static ZoneStatus Create(string? name, string? nameAr, bool isActive)
        {

            return new ZoneStatus(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
