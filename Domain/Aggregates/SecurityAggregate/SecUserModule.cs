using Domain.Aggregates.UserAggregate;
using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.SecurityAggregate
{
    public class SecUserModule : AggregateRootEntityBase<int>
    {
        public int UserId { get; set; }
        public int SecModuleId { get; set; }
        public bool? IsAllowed { get; set; }
        public SecModule? SecModule { get; set; }
        public User? User { get; set; }

        public SecUserModule()
        {
        }

        public SecUserModule(int userId, int secModuleId, bool? isAllowed, bool isActive) : this()
        {
            UserId = userId;
            SecModuleId = secModuleId;
            IsAllowed = isAllowed;
            IsActive = isActive;
        }

        public static SecUserModule Create(int userId, int secModuleId, bool? isAllowed, bool isActive)
        {

            return new SecUserModule(userId, secModuleId, isAllowed, isActive);
        }

        public void Update(int userId, int secModuleId, bool? isAllowed, bool isActive)
        {
            UserId = userId;
            SecModuleId = secModuleId;
            IsAllowed = isAllowed;
            IsActive = isActive;
        }
    }
}
