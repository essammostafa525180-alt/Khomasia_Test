using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.NotificationAggregate
{
    public class Notification : AggregateRootEntityBase<int>
    {
        public string? To { get; set; }
        public string? Cc { get; set; }
        public string? Bcc { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public DateTime? SendDate { get; set; }
        public int? NotificationTypeId { get; set; }
        public string? NotificationSource { get; set; }
        public string? ErrorMessage { get; set; }
        public int? SendTries { get; set; }
        public DateTime? NotificationDateTime { get; set; }
        public byte[]? Attachment { get; set; }
        public string? AttachmentType { get; set; }
        public NotificationType? NotificationType { get; set; }
        public NotificationState? Status { get; set; }

        public Notification()
        {
        }

        public Notification(string? to, string? cc, string? bcc, string? phoneNumber, string? subject, string? body, int? statusId, DateTime? createDate, DateTime? lastUpdateDate, DateTime? sendDate, int? notificationTypeId, string? notificationSource, string? errorMessage, int? sendTries, DateTime? notificationDateTime, byte[]? attachment, string? attachmentType, bool isActive) : this()
        {
            To = to;
            Cc = cc;
            Bcc = bcc;
            PhoneNumber = phoneNumber;
            Subject = subject;
            Body = body;
            StatusId = statusId;
            CreateDate = createDate;
            LastUpdateDate = lastUpdateDate;
            SendDate = sendDate;
            NotificationTypeId = notificationTypeId;
            NotificationSource = notificationSource;
            ErrorMessage = errorMessage;
            SendTries = sendTries;
            NotificationDateTime = notificationDateTime;
            Attachment = attachment;
            AttachmentType = attachmentType;
            IsActive = isActive;
        }

        public static Notification Create(string? to, string? cc, string? bcc, string? phoneNumber, string? subject, string? body, int? statusId, DateTime? createDate, DateTime? lastUpdateDate, DateTime? sendDate, int? notificationTypeId, string? notificationSource, string? errorMessage, int? sendTries, DateTime? notificationDateTime, byte[]? attachment, string? attachmentType, bool isActive)
        {

            return new Notification(to, cc, bcc, phoneNumber, subject, body, statusId, createDate, lastUpdateDate, sendDate, notificationTypeId, notificationSource, errorMessage, sendTries, notificationDateTime, attachment, attachmentType, isActive);
        }

        public void Update(string? to, string? cc, string? bcc, string? phoneNumber, string? subject, string? body, int? statusId, DateTime? createDate, DateTime? lastUpdateDate, DateTime? sendDate, int? notificationTypeId, string? notificationSource, string? errorMessage, int? sendTries, DateTime? notificationDateTime, byte[]? attachment, string? attachmentType, bool isActive)
        {
            To = to;
            Cc = cc;
            Bcc = bcc;
            PhoneNumber = phoneNumber;
            Subject = subject;
            Body = body;
            StatusId = statusId;
            CreateDate = createDate;
            LastUpdateDate = lastUpdateDate;
            SendDate = sendDate;
            NotificationTypeId = notificationTypeId;
            NotificationSource = notificationSource;
            ErrorMessage = errorMessage;
            SendTries = sendTries;
            NotificationDateTime = notificationDateTime;
            Attachment = attachment;
            AttachmentType = attachmentType;
            IsActive = isActive;
        }
    }
}
