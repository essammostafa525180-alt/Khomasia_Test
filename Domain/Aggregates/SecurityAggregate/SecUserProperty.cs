using Domain.Aggregates.UserAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.SecurityAggregate
{
    public class SecUserProperty : AggregateRootEntityBase<int>
    {
        public int? UserId { get; set; }
        public int? PropertyId { get; set; }
        public int? Mode { get; set; }
        public SecProperty? Property { get; set; }
        public User? User { get; set; }

        private List<SecUserSecurableValue> _secUserSecurableValues = new List<SecUserSecurableValue>();
        public IReadOnlyCollection<SecUserSecurableValue> SecUserSecurableValues => _secUserSecurableValues;

        public SecUserProperty()
        {
        }

        public SecUserProperty(int? userId, int? propertyId, int? mode, bool isActive) : this()
        {
            UserId = userId;
            PropertyId = propertyId;
            Mode = mode;
            IsActive = isActive;
        }

        public static SecUserProperty Create(int? userId, int? propertyId, int? mode, bool isActive)
        {

            return new SecUserProperty(userId, propertyId, mode, isActive);
        }

        public void Update(int? userId, int? propertyId, int? mode, bool isActive)
        {
            UserId = userId;
            PropertyId = propertyId;
            Mode = mode;
            IsActive = isActive;
        }
    }
}
