using Domain.Primitives;

namespace Domain.Entities
{
    public class TransfereType : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private TransfereType()
        {
        }

        public TransfereType(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static TransfereType Create(string? name, string? nameAr, bool isActive)
        {

            return new TransfereType(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
