using Domain.Primitives;

namespace Domain.Entities
{
    public class SecConfiguration : AuditableEntityBase<int>
    {
        public string? Key { get; private set; }
        public string? Value { get; private set; }

        private SecConfiguration()
        {
        }

        public SecConfiguration(string? key, string? value, bool isActive) : this()
        {
            Key = key;
            Value = value;
            IsActive = isActive;
        }

        public static SecConfiguration Create(string? key, string? value, bool isActive)
        {

            return new SecConfiguration(key, value, isActive);
        }

        public void Update(string? key, string? value, bool isActive)
        {
            Key = key;
            Value = value;
            IsActive = isActive;
        }
    }
}
