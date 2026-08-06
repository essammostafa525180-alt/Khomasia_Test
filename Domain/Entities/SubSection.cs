using Domain.Aggregates.AssetAggregate;
using Domain.Aggregates.ZoneAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class SubSection : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public int? SectionFk { get; private set; }
        public Section? SectionFkNavigation { get; private set; }

        private List<AssetCommissioning> _assetCommissionings = new List<AssetCommissioning>();
        public IReadOnlyCollection<AssetCommissioning> AssetCommissionings => _assetCommissionings;

        private List<Zone> _zones = new List<Zone>();
        public IReadOnlyCollection<Zone> Zones => _zones;

        private SubSection()
        {
        }

        public SubSection(string? code, string? name, string? nameAr, int? sectionFk, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            SectionFk = sectionFk;
            IsActive = isActive;
        }

        public static SubSection Create(string? code, string? name, string? nameAr, int? sectionFk, bool isActive)
        {

            return new SubSection(code, name, nameAr, sectionFk, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, int? sectionFk, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            SectionFk = sectionFk;
            IsActive = isActive;
        }
    }
}
