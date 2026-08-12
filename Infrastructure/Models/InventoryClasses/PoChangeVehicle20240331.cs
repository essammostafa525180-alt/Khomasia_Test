using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class PoChangeVehicle20240331
{
    public string? RequestNo { get; set; }

    public string? CurrentVehicleCode { get; set; }

    public long? Mrid { get; set; }

    public long? OldVehicleId { get; set; }

    public long? VehicleId { get; set; }
}
