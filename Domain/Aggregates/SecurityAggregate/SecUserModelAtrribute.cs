using Domain.Aggregates.UserAggregate;
using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.SecurityAggregate
{
    public class SecUserModelAtrribute : AggregateRootEntityBase<int>
    {
        public int UserId { get; set; }
        public int ModelAttributeId { get; set; }
        public int? Mode { get; set; }
        public SecModelAttribute? ModelAttribute { get; set; }
        public User? User { get; set; }

        public SecUserModelAtrribute()
        {
        }

        public SecUserModelAtrribute(int userId, int modelAttributeId, int? mode, bool isActive) : this()
        {
            UserId = userId;
            ModelAttributeId = modelAttributeId;
            Mode = mode;
            IsActive = isActive;
        }

        public static SecUserModelAtrribute Create(int userId, int modelAttributeId, int? mode, bool isActive)
        {

            return new SecUserModelAtrribute(userId, modelAttributeId, mode, isActive);
        }

        public void Update(int userId, int modelAttributeId, int? mode, bool isActive)
        {
            UserId = userId;
            ModelAttributeId = modelAttributeId;
            Mode = mode;
            IsActive = isActive;
        }
    }
}
