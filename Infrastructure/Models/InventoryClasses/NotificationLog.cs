using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class NotificationLog
{
    public long Id { get; set; }

    public long? CustomerId { get; set; }

    public long? TemplateId { get; set; }

    public long? LoyaltyLevelId { get; set; }

    public DateTime? CreatedOn { get; set; }
}
