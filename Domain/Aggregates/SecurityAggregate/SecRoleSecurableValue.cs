using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.SecurityAggregate
{
    public class SecRoleSecurableValue : AggregateRootEntityBase<int>
    {
        public string? Value { get; set; }
        public int? SecRolePropertyId { get; set; }
        public SecRoleProperty? SecRoleProperty { get; set; }

        public SecRoleSecurableValue()
        {
        }

        public SecRoleSecurableValue(string? value, int? secRolePropertyId, bool isActive) : this()
        {
            Value = value;
            SecRolePropertyId = secRolePropertyId;
            IsActive = isActive;
        }

        public static SecRoleSecurableValue Create(string? value, int? secRolePropertyId, bool isActive)
        {

            return new SecRoleSecurableValue(value, secRolePropertyId, isActive);
        }

        public void Update(string? value, int? secRolePropertyId, bool isActive)
        {
            Value = value;
            SecRolePropertyId = secRolePropertyId;
            IsActive = isActive;
        }
    }
}
