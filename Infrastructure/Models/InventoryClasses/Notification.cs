using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Notification
{
    public long Id { get; set; }

    public string? To { get; set; }

    public string? Cc { get; set; }

    public string? Bcc { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Subject { get; set; }

    public string? Body { get; set; }

    public long? StatusId { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public DateTime? SendDate { get; set; }

    public long? NotificationTypeId { get; set; }

    public bool IsActive { get; set; }

    public string? NotificationSource { get; set; }

    public string? ErrorMessage { get; set; }

    public int? SendTries { get; set; }

    public DateTime? NotificationDateTime { get; set; }

    public byte[]? Attachment { get; set; }

    public string? AttachmentType { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual NotificationType? NotificationType { get; set; }

    public virtual NotificationState? Status { get; set; }
}
