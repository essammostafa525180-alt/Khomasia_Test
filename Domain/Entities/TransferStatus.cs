using Domain.Aggregates.InventoryTransfereAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class TransferStatus : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<InventoryTransfere> _inventoryTransferes = new List<InventoryTransfere>();
        public IReadOnlyCollection<InventoryTransfere> InventoryTransferes => _inventoryTransferes;

        private TransferStatus()
        {
        }

        public TransferStatus(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static TransferStatus Create(string? name, string? nameAr, bool isActive)
        {

            return new TransferStatus(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
