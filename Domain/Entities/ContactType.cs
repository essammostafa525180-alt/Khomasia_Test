using Domain.Aggregates.SalesAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ContactType : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public DateTime? UpdatedOn { get; private set; }

        private List<Contact> _contacts = new List<Contact>();
        public IReadOnlyCollection<Contact> Contacts => _contacts;

        private ContactType()
        {
        }

        public ContactType(string? name, string? nameAr, DateTime? updatedOn, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            UpdatedOn = updatedOn;
            IsActive = isActive;
        }

        public static ContactType Create(string? name, string? nameAr, DateTime? updatedOn, bool isActive)
        {

            return new ContactType(name, nameAr, updatedOn, isActive);
        }

        public void Update(string? name, string? nameAr, DateTime? updatedOn, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            UpdatedOn = updatedOn;
            IsActive = isActive;
        }
    }
}
