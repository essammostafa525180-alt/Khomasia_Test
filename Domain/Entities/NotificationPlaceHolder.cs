using Domain.Primitives;

namespace Domain.Entities
{
    public class NotificationPlaceHolder : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public string? Value { get; private set; }

        private NotificationPlaceHolder()
        {
        }

        public NotificationPlaceHolder(string? name, string? nameAr, string? value, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            Value = value;
            IsActive = isActive;
        }

        public static NotificationPlaceHolder Create(string? name, string? nameAr, string? value, bool isActive)
        {

            return new NotificationPlaceHolder(name, nameAr, value, isActive);
        }

        public void Update(string? name, string? nameAr, string? value, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            Value = value;
            IsActive = isActive;
        }
    }
}
