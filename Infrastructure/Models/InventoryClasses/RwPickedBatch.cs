using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class RwPickedBatch
{
    public long Id { get; set; }

    public long? RequestWdfk { get; set; }

    public decimal? ReturnedQuantity { get; set; }

    public decimal? PickedQuantity { get; set; }

    public DateTime? PickedDate { get; set; }

    public long? BatchFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool? IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public bool? Axsynced { get; set; }

    public virtual ICollection<RwPickedSerial> RwPickedSerials { get; set; } = new List<RwPickedSerial>();
}
