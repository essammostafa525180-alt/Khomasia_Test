using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Visit
{
    public long Id { get; set; }

    public long? CustomerId { get; set; }

    public long? UserId { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public string? Image { get; set; }

    public string? OtherSupplier { get; set; }

    public DateTime? CreatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public long? UpdatedBy { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual User? User { get; set; }
}
