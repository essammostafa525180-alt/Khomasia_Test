using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class InventoryItemTransactionType : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<InventoryItemLocationDetail> _inventoryItemLocationDetails = new List<InventoryItemLocationDetail>();
        public IReadOnlyCollection<InventoryItemLocationDetail> InventoryItemLocationDetails => _inventoryItemLocationDetails;

        private InventoryItemTransactionType()
        {
        }

        public InventoryItemTransactionType(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static InventoryItemTransactionType Create(string? name, string? nameAr, bool isActive)
        {

            return new InventoryItemTransactionType(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
