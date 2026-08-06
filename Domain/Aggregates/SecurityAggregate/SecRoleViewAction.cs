using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.SecurityAggregate
{
    public class SecRoleViewAction : AggregateRootEntityBase<int>
    {
        public int ViewActionId { get; set; }
        public int RoleId { get; set; }
        public bool? IsAllow { get; set; }
        public SecRole? Role { get; set; }
        public SecViewAction? ViewAction { get; set; }

        public SecRoleViewAction()
        {
        }

        public SecRoleViewAction(int viewActionId, int roleId, bool? isAllow, bool isActive) : this()
        {
            ViewActionId = viewActionId;
            RoleId = roleId;
            IsAllow = isAllow;
            IsActive = isActive;
        }

        public static SecRoleViewAction Create(int viewActionId, int roleId, bool? isAllow, bool isActive)
        {

            return new SecRoleViewAction(viewActionId, roleId, isAllow, isActive);
        }

        public void Update(int viewActionId, int roleId, bool? isAllow, bool isActive)
        {
            ViewActionId = viewActionId;
            RoleId = roleId;
            IsAllow = isAllow;
            IsActive = isActive;
        }
    }
}
