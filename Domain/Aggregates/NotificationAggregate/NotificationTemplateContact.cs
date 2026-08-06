using Domain.Aggregates.SalesAggregate;
using Domain.Primitives;

namespace Domain.Aggregates.NotificationAggregate
{
    public class NotificationTemplateContact : AggregateRootEntityBase<int>
    {
        public int? ContactId { get; set; }
        public int? TemplateId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Contact? Contact { get; set; }
        public NotificationTemplate? Template { get; set; }

        public NotificationTemplateContact()
        {
        }

        public NotificationTemplateContact(int? contactId, int? templateId, DateTime? updatedOn, bool isActive) : this()
        {
            ContactId = contactId;
            TemplateId = templateId;
            UpdatedOn = updatedOn;
            IsActive = isActive;
        }

        public static NotificationTemplateContact Create(int? contactId, int? templateId, DateTime? updatedOn, bool isActive)
        {

            return new NotificationTemplateContact(contactId, templateId, updatedOn, isActive);
        }

        public void Update(int? contactId, int? templateId, DateTime? updatedOn, bool isActive)
        {
            ContactId = contactId;
            TemplateId = templateId;
            UpdatedOn = updatedOn;
            IsActive = isActive;
        }
    }
}
