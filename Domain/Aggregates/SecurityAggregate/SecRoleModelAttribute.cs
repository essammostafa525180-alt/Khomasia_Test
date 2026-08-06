using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.SecurityAggregate
{
    public class SecRoleModelAttribute : AggregateRootEntityBase<int>
    {
        public int RoleId { get; set; }
        public int ModelAttributeId { get; set; }
        public int? Mode { get; set; }
        public SecModelAttribute? ModelAttribute { get; set; }
        public SecRole? Role { get; set; }

        public SecRoleModelAttribute()
        {
        }

        public SecRoleModelAttribute(int roleId, int modelAttributeId, int? mode, bool isActive) : this()
        {
            RoleId = roleId;
            ModelAttributeId = modelAttributeId;
            Mode = mode;
            IsActive = isActive;
        }

        public static SecRoleModelAttribute Create(int roleId, int modelAttributeId, int? mode, bool isActive)
        {

            return new SecRoleModelAttribute(roleId, modelAttributeId, mode, isActive);
        }

        public void Update(int roleId, int modelAttributeId, int? mode, bool isActive)
        {
            RoleId = roleId;
            ModelAttributeId = modelAttributeId;
            Mode = mode;
            IsActive = isActive;
        }
    }
}
