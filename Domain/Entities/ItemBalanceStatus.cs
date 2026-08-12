using Domain.Primitives;

namespace Domain.Entities
{
    public class ItemBalanceStatus : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private ItemBalanceStatus()
        {
        }

        public ItemBalanceStatus(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static ItemBalanceStatus Create(string? name, string? nameAr, bool isActive)
        {

            return new ItemBalanceStatus(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
