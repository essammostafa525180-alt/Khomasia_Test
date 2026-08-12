using Domain.Aggregates.AssetAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class EquipmentCode : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<Asset> _assets = new List<Asset>();
        public IReadOnlyCollection<Asset> Assets => _assets;

        private EquipmentCode()
        {
        }

        public EquipmentCode(string? code, string? name, string? nameAr, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static EquipmentCode Create(string? code, string? name, string? nameAr, bool isActive)
        {

            return new EquipmentCode(code, name, nameAr, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
