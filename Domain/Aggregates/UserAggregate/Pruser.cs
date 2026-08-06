using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.UserAggregate
{
    public class Pruser : AggregateRootEntityBase<int>
    {
        public int ApprovalScreenFk { get; set; }
        public int UserFk { get; set; }
        public ApprovalScreen? ApprovalScreenFkNavigation { get; set; }
        public User? UserFkNavigation { get; set; }

        public Pruser()
        {
        }

        public Pruser(int approvalScreenFk, int userFk, bool isActive) : this()
        {
            ApprovalScreenFk = approvalScreenFk;
            UserFk = userFk;
            IsActive = isActive;
        }

        public static Pruser Create(int approvalScreenFk, int userFk, bool isActive)
        {

            return new Pruser(approvalScreenFk, userFk, isActive);
        }

        public void Update(int approvalScreenFk, int userFk, bool isActive)
        {
            ApprovalScreenFk = approvalScreenFk;
            UserFk = userFk;
            IsActive = isActive;
        }
    }
}
