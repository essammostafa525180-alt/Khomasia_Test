using Domain.Aggregates.UserAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.AuditAggregate
{
    public class AuditTrail : AggregateRootEntityBase<int>
    {
        public string? TableName { get; set; }
        public string? Action { get; set; }
        public DateTime? ExecutedAt { get; set; }
        public int? UserId { get; set; }
        public int? EntityId { get; set; }
        public string? ClientComputerName { get; set; }
        public string? ClientIp { get; set; }
        public int? ParentAuditTrailId { get; set; }
        public AuditTrail? ParentAuditTrail { get; set; }
        public User? User { get; set; }

        private List<AuditTrailDetail> _auditTrailDetails = new List<AuditTrailDetail>();
        public IReadOnlyCollection<AuditTrailDetail> AuditTrailDetails => _auditTrailDetails;

        private List<AuditTrail> _inverseParentAuditTrail = new List<AuditTrail>();
        public IReadOnlyCollection<AuditTrail> InverseParentAuditTrail => _inverseParentAuditTrail;

        public AuditTrail()
        {
        }

        public AuditTrail(string? tableName, string? action, DateTime? executedAt, int? userId, int? entityId, string? clientComputerName, string? clientIp, int? parentAuditTrailId, bool isActive) : this()
        {
            TableName = tableName;
            Action = action;
            ExecutedAt = executedAt;
            UserId = userId;
            EntityId = entityId;
            ClientComputerName = clientComputerName;
            ClientIp = clientIp;
            ParentAuditTrailId = parentAuditTrailId;
            IsActive = isActive;
        }

        public static AuditTrail Create(string? tableName, string? action, DateTime? executedAt, int? userId, int? entityId, string? clientComputerName, string? clientIp, int? parentAuditTrailId, bool isActive)
        {

            return new AuditTrail(tableName, action, executedAt, userId, entityId, clientComputerName, clientIp, parentAuditTrailId, isActive);
        }

        public void Update(string? tableName, string? action, DateTime? executedAt, int? userId, int? entityId, string? clientComputerName, string? clientIp, int? parentAuditTrailId, bool isActive)
        {
            TableName = tableName;
            Action = action;
            ExecutedAt = executedAt;
            UserId = userId;
            EntityId = entityId;
            ClientComputerName = clientComputerName;
            ClientIp = clientIp;
            ParentAuditTrailId = parentAuditTrailId;
            IsActive = isActive;
        }
    }
}
