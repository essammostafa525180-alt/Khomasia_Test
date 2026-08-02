using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class ModuleSetting
{
    public long Id { get; set; }

    public string? SettingName { get; set; }

    public string? SettingValue { get; set; }

    public string? Measure { get; set; }

    public string? MeasureAr { get; set; }

    public int? DataType { get; set; }
}
