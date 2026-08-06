using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.SecurityAggregate
{
    public class SecRoleModule : AggregateRootEntityBase<int>
    {
        public int SecRoleId { get; set; }
        public int SecModuleId { get; set; }
        public bool? IsAllowed { get; set; }
        public SecModule? SecModule { get; set; }
        public SecRole? SecRole { get; set; }

        public SecRoleModule()
        {
        }

        public SecRoleModule(int secRoleId, int secModuleId, bool? isAllowed, bool isActive) : this()
        {
            SecRoleId = secRoleId;
            SecModuleId = secModuleId;
            IsAllowed = isAllowed;
            IsActive = isActive;
        }

        public static SecRoleModule Create(int secRoleId, int secModuleId, bool? isAllowed, bool isActive)
        {

            return new SecRoleModule(secRoleId, secModuleId, isAllowed, isActive);
        }

        public void Update(int secRoleId, int secModuleId, bool? isAllowed, bool isActive)
        {
            SecRoleId = secRoleId;
            SecModuleId = secModuleId;
            IsAllowed = isAllowed;
            IsActive = isActive;
        }
    }
}
