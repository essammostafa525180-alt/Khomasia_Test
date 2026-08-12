using Domain.Primitives;

namespace Domain.Aggregates.AuditAggregate
{
    public class AuditTrailDetail : AggregateRootEntityBase<int>
    {
        public int? AuditTrailId { get; set; }
        public string? Property { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public string? ReferenceTable { get; set; }
        public AuditTrail? AuditTrail { get; set; }

        public AuditTrailDetail()
        {
        }

        public AuditTrailDetail(int? auditTrailId, string? property, string? oldValue, string? newValue, string? referenceTable, bool isActive) : this()
        {
            AuditTrailId = auditTrailId;
            Property = property;
            OldValue = oldValue;
            NewValue = newValue;
            ReferenceTable = referenceTable;
            IsActive = isActive;
        }

        public static AuditTrailDetail Create(int? auditTrailId, string? property, string? oldValue, string? newValue, string? referenceTable, bool isActive)
        {

            return new AuditTrailDetail(auditTrailId, property, oldValue, newValue, referenceTable, isActive);
        }

        public void Update(int? auditTrailId, string? property, string? oldValue, string? newValue, string? referenceTable, bool isActive)
        {
            AuditTrailId = auditTrailId;
            Property = property;
            OldValue = oldValue;
            NewValue = newValue;
            ReferenceTable = referenceTable;
            IsActive = isActive;
        }
    }
}
