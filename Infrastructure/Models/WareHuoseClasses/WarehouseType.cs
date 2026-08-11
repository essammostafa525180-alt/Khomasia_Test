using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models.WareHuoseClasses
{
    public class WarehouseType
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;


        // Navigation
        public ICollection<Warehouse> Warehouses { get; set; }
            = new List<Warehouse>();
    }

}
