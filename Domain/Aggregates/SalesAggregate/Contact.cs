using Domain.Aggregates.NotificationAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.SalesAggregate
{
    public class Contact : AggregateRootEntityBase<int>
    {
        public string? ContactValue { get; set; }
        public int? ContactTypeId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public ContactType? ContactType { get; set; }

        private List<NotificationTemplateContact> _notificationTemplateContacts = new List<NotificationTemplateContact>();
        public IReadOnlyCollection<NotificationTemplateContact> NotificationTemplateContacts => _notificationTemplateContacts;

        public Contact()
        {
        }

        public Contact(string? contactValue, int? contactTypeId, DateTime? updatedOn, bool isActive) : this()
        {
            ContactValue = contactValue;
            ContactTypeId = contactTypeId;
            UpdatedOn = updatedOn;
            IsActive = isActive;
        }

        public static Contact Create(string? contactValue, int? contactTypeId, DateTime? updatedOn, bool isActive)
        {

            return new Contact(contactValue, contactTypeId, updatedOn, isActive);
        }

        public void Update(string? contactValue, int? contactTypeId, DateTime? updatedOn, bool isActive)
        {
            ContactValue = contactValue;
            ContactTypeId = contactTypeId;
            UpdatedOn = updatedOn;
            IsActive = isActive;
        }
    }
}
