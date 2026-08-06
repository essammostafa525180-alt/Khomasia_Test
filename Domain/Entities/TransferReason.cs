using Domain.Aggregates.InventoryTransfereAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class TransferReason : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<InventoryTransfere> _inventoryTransferes = new List<InventoryTransfere>();
        public IReadOnlyCollection<InventoryTransfere> InventoryTransferes => _inventoryTransferes;

        private TransferReason()
        {
        }

        public TransferReason(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static TransferReason Create(string? name, string? nameAr, bool isActive)
        {

            return new TransferReason(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
