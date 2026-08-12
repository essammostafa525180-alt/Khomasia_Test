using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Contact
{
    public long Id { get; set; }

    public string? ContactValue { get; set; }

    public long? ContactTypeId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool? IsActive { get; set; }

    public virtual ContactType? ContactType { get; set; }

    public virtual ICollection<NotificationTemplateContact> NotificationTemplateContacts { get; set; } = new List<NotificationTemplateContact>();
}
