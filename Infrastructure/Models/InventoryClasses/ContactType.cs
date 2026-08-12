using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class ContactType
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();
}
