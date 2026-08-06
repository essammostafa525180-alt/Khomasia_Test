using Domain.Aggregates.UserAggregate;
using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.SecurityAggregate
{
    public class SecUserViewAction : AggregateRootEntityBase<int>
    {
        public int UserId { get; set; }
        public int ViewActionId { get; set; }
        public bool? IsAllow { get; set; }
        public User? User { get; set; }
        public SecViewAction? ViewAction { get; set; }

        public SecUserViewAction()
        {
        }

        public SecUserViewAction(int userId, int viewActionId, bool? isAllow, bool isActive) : this()
        {
            UserId = userId;
            ViewActionId = viewActionId;
            IsAllow = isAllow;
            IsActive = isActive;
        }

        public static SecUserViewAction Create(int userId, int viewActionId, bool? isAllow, bool isActive)
        {

            return new SecUserViewAction(userId, viewActionId, isAllow, isActive);
        }

        public void Update(int userId, int viewActionId, bool? isAllow, bool isActive)
        {
            UserId = userId;
            ViewActionId = viewActionId;
            IsAllow = isAllow;
            IsActive = isActive;
        }
    }
}
