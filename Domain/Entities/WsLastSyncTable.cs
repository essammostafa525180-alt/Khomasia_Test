using Domain.Primitives;

namespace Domain.Entities
{
    public class WsLastSyncTable : AuditableEntityBase<int>
    {
        public string? Key { get; private set; }
        public string? Value { get; private set; }

        private WsLastSyncTable()
        {
        }

        public WsLastSyncTable(string? key, string? value, bool isActive) : this()
        {
            Key = key;
            Value = value;
            IsActive = isActive;
        }

        public static WsLastSyncTable Create(string? key, string? value, bool isActive)
        {

            return new WsLastSyncTable(key, value, isActive);
        }

        public void Update(string? key, string? value, bool isActive)
        {
            Key = key;
            Value = value;
            IsActive = isActive;
        }
    }
}
