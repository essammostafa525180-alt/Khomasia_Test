using Domain.Primitives;

namespace Domain.Entities
{
    public class InventoryItemTrasnsactionType : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private InventoryItemTrasnsactionType()
        {
        }

        public InventoryItemTrasnsactionType(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static InventoryItemTrasnsactionType Create(string? name, string? nameAr, bool isActive)
        {

            return new InventoryItemTrasnsactionType(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
