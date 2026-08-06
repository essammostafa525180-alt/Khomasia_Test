using Domain.Primitives;

namespace Domain.Aggregates.SalesAggregate
{
    public class SalesInvoiceItem : AggregateRootEntityBase<int>
    {
        public int? SalesInvoiceId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
        public decimal? NetAmount { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public SalesInvoice? SalesInvoice { get; set; }

        public SalesInvoiceItem()
        {
        }

        public SalesInvoiceItem(int? salesInvoiceId, int? productId, int? quantity, decimal? price, decimal? discount, decimal? netAmount, DateTime? updatedOn, int? updatedBy, bool isActive) : this()
        {
            SalesInvoiceId = salesInvoiceId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
            Discount = discount;
            NetAmount = netAmount;
            UpdatedOn = updatedOn;
            UpdatedBy = updatedBy;
            IsActive = isActive;
        }

        public static SalesInvoiceItem Create(int? salesInvoiceId, int? productId, int? quantity, decimal? price, decimal? discount, decimal? netAmount, DateTime? updatedOn, int? updatedBy, bool isActive)
        {

            return new SalesInvoiceItem(salesInvoiceId, productId, quantity, price, discount, netAmount, updatedOn, updatedBy, isActive);
        }

        public void Update(int? salesInvoiceId, int? productId, int? quantity, decimal? price, decimal? discount, decimal? netAmount, DateTime? updatedOn, int? updatedBy, bool isActive)
        {
            SalesInvoiceId = salesInvoiceId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
            Discount = discount;
            NetAmount = netAmount;
            UpdatedOn = updatedOn;
            UpdatedBy = updatedBy;
            IsActive = isActive;
        }
    }
}
