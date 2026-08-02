using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class NotificationTemplateContact
{
    public long Id { get; set; }

    public long? ContactId { get; set; }

    public long? TemplateId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual Contact? Contact { get; set; }

    public virtual NotificationTemplate? Template { get; set; }
}
