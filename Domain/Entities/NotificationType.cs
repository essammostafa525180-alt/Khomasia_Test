using Domain.Aggregates.NotificationAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class NotificationType : AuditableEntityBase<int>
    {
        public string? NotificationTypeEn { get; private set; }
        public string? NotificationTypeAr { get; private set; }

        private List<NotificationTemplate> _notificationTemplates = new List<NotificationTemplate>();
        public IReadOnlyCollection<NotificationTemplate> NotificationTemplates => _notificationTemplates;

        private List<Notification> _notifications = new List<Notification>();
        public IReadOnlyCollection<Notification> Notifications => _notifications;

        private NotificationType()
        {
        }

        public NotificationType(string? notificationTypeEn, string? notificationTypeAr, bool isActive) : this()
        {
            NotificationTypeEn = notificationTypeEn;
            NotificationTypeAr = notificationTypeAr;
            IsActive = isActive;
        }

        public static NotificationType Create(string? notificationTypeEn, string? notificationTypeAr, bool isActive)
        {

            return new NotificationType(notificationTypeEn, notificationTypeAr, isActive);
        }

        public void Update(string? notificationTypeEn, string? notificationTypeAr, bool isActive)
        {
            NotificationTypeEn = notificationTypeEn;
            NotificationTypeAr = notificationTypeAr;
            IsActive = isActive;
        }
    }
}
