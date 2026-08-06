using Domain.Primitives;

namespace Domain.Entities
{
    public class InventoryItemStatus : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private InventoryItemStatus()
        {
        }

        public InventoryItemStatus(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static InventoryItemStatus Create(string? name, string? nameAr, bool isActive)
        {

            return new InventoryItemStatus(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
