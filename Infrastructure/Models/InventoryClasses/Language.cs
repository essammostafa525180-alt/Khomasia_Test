using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Language
{
    public long Id { get; set; }

    public string? LanguageName { get; set; }

    public string? LanguageNameAr { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<NotificationTemplate> NotificationTemplates { get; set; } = new List<NotificationTemplate>();
}
