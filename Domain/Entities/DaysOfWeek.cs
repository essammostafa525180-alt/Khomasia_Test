using Domain.Primitives;

namespace Domain.Entities
{
    public class DaysOfWeek : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private DaysOfWeek()
        {
        }

        public DaysOfWeek(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static DaysOfWeek Create(string? name, string? nameAr, bool isActive)
        {

            return new DaysOfWeek(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
