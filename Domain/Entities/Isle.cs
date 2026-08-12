using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Isle : AuditableEntityBase<int>
    {
        public int StorageUnitFk { get; private set; }
        public StorageUnit? StorageUnitFkNavigation { get; private set; }
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public int Sequence { get; private set; }

        private List<Shelf> _shelves = new List<Shelf>();
        public IReadOnlyCollection<Shelf> Shelves => _shelves;

        private Isle() { }

        public Isle(int storageUnitFk, string? code, string? name, int sequence, bool isActive) : this()
        {
            StorageUnitFk = storageUnitFk;
            Code = code;
            Name = name;
            Sequence = sequence;
            IsActive = isActive;
        }

        public static Isle Create(int storageUnitFk, string? code, string? name, int sequence, bool isActive)
        {
            return new Isle(storageUnitFk, code, name, sequence, isActive);
        }

        public void Update(int storageUnitFk, string? code, string? name, int sequence, bool isActive)
        {
            StorageUnitFk = storageUnitFk;
            Code = code;
            Name = name;
            Sequence = sequence;
            IsActive = isActive;
        }
    }
}
