using Domain.Aggregates.VendorOrderAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.SalesAggregate
{
    public class SalesQuotation : AggregateRootEntityBase<int>
    {
        public int? CompanyFk { get; set; }
        public int? RequestForQuotationFk { get; set; }
        public string? OrderNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateOnly? ExpectedDeliveryDate { get; set; }
        public int? CustomerFk { get; set; }
        public string? Notes { get; set; }
        public decimal? TotalRatio { get; set; }
        public decimal? TotalCost { get; set; }
        public Customer? CustomerFkNavigation { get; set; }
        public VendorOrder? RequestForQuotationFkNavigation { get; set; }

        private List<SalesQuotationDetail> _salesQuotationDetails = new List<SalesQuotationDetail>();
        public IReadOnlyCollection<SalesQuotationDetail> SalesQuotationDetails => _salesQuotationDetails;

        public SalesQuotation()
        {
        }

        public SalesQuotation(int? companyFk, int? requestForQuotationFk, string? orderNo, DateTime? orderDate, DateOnly? expectedDeliveryDate, int? customerFk, string? notes, decimal? totalRatio, decimal? totalCost, bool isActive) : this()
        {
            CompanyFk = companyFk;
            RequestForQuotationFk = requestForQuotationFk;
            OrderNo = orderNo;
            OrderDate = orderDate;
            ExpectedDeliveryDate = expectedDeliveryDate;
            CustomerFk = customerFk;
            Notes = notes;
            TotalRatio = totalRatio;
            TotalCost = totalCost;
            IsActive = isActive;
        }

        public static SalesQuotation Create(int? companyFk, int? requestForQuotationFk, string? orderNo, DateTime? orderDate, DateOnly? expectedDeliveryDate, int? customerFk, string? notes, decimal? totalRatio, decimal? totalCost, bool isActive)
        {

            return new SalesQuotation(companyFk, requestForQuotationFk, orderNo, orderDate, expectedDeliveryDate, customerFk, notes, totalRatio, totalCost, isActive);
        }

        public void Update(int? companyFk, int? requestForQuotationFk, string? orderNo, DateTime? orderDate, DateOnly? expectedDeliveryDate, int? customerFk, string? notes, decimal? totalRatio, decimal? totalCost, bool isActive)
        {
            CompanyFk = companyFk;
            RequestForQuotationFk = requestForQuotationFk;
            OrderNo = orderNo;
            OrderDate = orderDate;
            ExpectedDeliveryDate = expectedDeliveryDate;
            CustomerFk = customerFk;
            Notes = notes;
            TotalRatio = totalRatio;
            TotalCost = totalCost;
            IsActive = isActive;
        }
    }
}
