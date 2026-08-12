using Domain.Aggregates.NotificationAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class NotificationState : AuditableEntityBase<int>
    {
        public string? StatusName { get; private set; }
        public string? StatusNameAr { get; private set; }

        private List<Notification> _notifications = new List<Notification>();
        public IReadOnlyCollection<Notification> Notifications => _notifications;

        private NotificationState()
        {
        }

        public NotificationState(string? statusName, string? statusNameAr, bool isActive) : this()
        {
            StatusName = statusName;
            StatusNameAr = statusNameAr;
            IsActive = isActive;
        }

        public static NotificationState Create(string? statusName, string? statusNameAr, bool isActive)
        {

            return new NotificationState(statusName, statusNameAr, isActive);
        }

        public void Update(string? statusName, string? statusNameAr, bool isActive)
        {
            StatusName = statusName;
            StatusNameAr = statusNameAr;
            IsActive = isActive;
        }
    }
}
