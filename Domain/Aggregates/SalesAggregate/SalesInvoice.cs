using Domain.Aggregates.UserAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.SalesAggregate
{
    public class SalesInvoice : AggregateRootEntityBase<int>
    {
        public int? CustomerId { get; set; }
        public int? UserId { get; set; }
        public string? Address { get; set; }
        public string? ContactPerson { get; set; }
        public decimal? Vatpercentage { get; set; }
        public decimal? Vatamount { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public Customer? Customer { get; set; }
        public User? User { get; set; }

        private List<SalesInvoiceItem> _salesInvoiceItems = new List<SalesInvoiceItem>();
        public IReadOnlyCollection<SalesInvoiceItem> SalesInvoiceItems => _salesInvoiceItems;

        public SalesInvoice()
        {
        }

        public SalesInvoice(int? customerId, int? userId, string? address, string? contactPerson, decimal? vatpercentage, decimal? vatamount, decimal? totalAmount, DateTime? updatedOn, int? updatedBy, bool isActive) : this()
        {
            CustomerId = customerId;
            UserId = userId;
            Address = address;
            ContactPerson = contactPerson;
            Vatpercentage = vatpercentage;
            Vatamount = vatamount;
            TotalAmount = totalAmount;
            UpdatedOn = updatedOn;
            UpdatedBy = updatedBy;
            IsActive = isActive;
        }

        public static SalesInvoice Create(int? customerId, int? userId, string? address, string? contactPerson, decimal? vatpercentage, decimal? vatamount, decimal? totalAmount, DateTime? updatedOn, int? updatedBy, bool isActive)
        {

            return new SalesInvoice(customerId, userId, address, contactPerson, vatpercentage, vatamount, totalAmount, updatedOn, updatedBy, isActive);
        }

        public void Update(int? customerId, int? userId, string? address, string? contactPerson, decimal? vatpercentage, decimal? vatamount, decimal? totalAmount, DateTime? updatedOn, int? updatedBy, bool isActive)
        {
            CustomerId = customerId;
            UserId = userId;
            Address = address;
            ContactPerson = contactPerson;
            Vatpercentage = vatpercentage;
            Vatamount = vatamount;
            TotalAmount = totalAmount;
            UpdatedOn = updatedOn;
            UpdatedBy = updatedBy;
            IsActive = isActive;
        }
    }
}
