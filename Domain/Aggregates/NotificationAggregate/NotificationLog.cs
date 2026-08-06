using Domain.Primitives;

namespace Domain.Aggregates.NotificationAggregate
{
    public class NotificationLog : AggregateRootEntityBase<int>
    {
        public int? CustomerId { get; set; }
        public int? TemplateId { get; set; }
        public int? LoyaltyLevelId { get; set; }

        public NotificationLog()
        {
        }

        public NotificationLog(int? customerId, int? templateId, int? loyaltyLevelId, bool isActive) : this()
        {
            CustomerId = customerId;
            TemplateId = templateId;
            LoyaltyLevelId = loyaltyLevelId;
            IsActive = isActive;
        }

        public static NotificationLog Create(int? customerId, int? templateId, int? loyaltyLevelId, bool isActive)
        {

            return new NotificationLog(customerId, templateId, loyaltyLevelId, isActive);
        }

        public void Update(int? customerId, int? templateId, int? loyaltyLevelId, bool isActive)
        {
            CustomerId = customerId;
            TemplateId = templateId;
            LoyaltyLevelId = loyaltyLevelId;
            IsActive = isActive;
        }
    }
}
