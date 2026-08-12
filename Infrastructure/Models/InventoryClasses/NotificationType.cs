using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class NotificationType
{
    public long Id { get; set; }

    public string? NotificationTypeEn { get; set; }

    public string? NotificationTypeAr { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<NotificationTemplate> NotificationTemplates { get; set; } = new List<NotificationTemplate>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
