using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class NotificationTemplate
{
    public long Id { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? NotificationTypeId { get; set; }

    public long? LanguageId { get; set; }

    public string? Subject { get; set; }

    public string? SubjectAr { get; set; }

    public string? BodySms { get; set; }

    public string? BodySmsar { get; set; }

    public string? BodyEmail { get; set; }

    public string? BodyEmailAr { get; set; }

    public string? Code { get; set; }

    public string? CodeAr { get; set; }

    public int? DurationInDays { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Language? Language { get; set; }

    public virtual ICollection<NotificationTemplateContact> NotificationTemplateContacts { get; set; } = new List<NotificationTemplateContact>();

    public virtual NotificationType? NotificationType { get; set; }
}
