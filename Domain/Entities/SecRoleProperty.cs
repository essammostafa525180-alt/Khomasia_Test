using Domain.Aggregates.SecurityAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class SecRoleProperty : AuditableEntityBase<int>
    {
        public int? RoleId { get; private set; }
        public int? PropertyId { get; private set; }
        public int? Mode { get; private set; }
        public SecProperty? Property { get; private set; }
        public SecRole? Role { get; private set; }

        private List<SecRoleSecurableValue> _secRoleSecurableValues = new List<SecRoleSecurableValue>();
        public IReadOnlyCollection<SecRoleSecurableValue> SecRoleSecurableValues => _secRoleSecurableValues;

        private SecRoleProperty()
        {
        }

        public SecRoleProperty(int? roleId, int? propertyId, int? mode, bool isActive) : this()
        {
            RoleId = roleId;
            PropertyId = propertyId;
            Mode = mode;
            IsActive = isActive;
        }

        public static SecRoleProperty Create(int? roleId, int? propertyId, int? mode, bool isActive)
        {

            return new SecRoleProperty(roleId, propertyId, mode, isActive);
        }

        public void Update(int? roleId, int? propertyId, int? mode, bool isActive)
        {
            RoleId = roleId;
            PropertyId = propertyId;
            Mode = mode;
            IsActive = isActive;
        }
    }
}
