using Domain.Aggregates.InventoryItemAggregate;
using Domain.Aggregates.VendorOrderAggregate;
using Domain.Primitives;

namespace Domain.Aggregates.SalesAggregate
{
    public class SalesQuotationDetail : AggregateRootEntityBase<int>
    {
        public int? SalesQuotationFk { get; set; }
        public int? RequestForQuotationDetailFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? VendorCostPrice { get; set; }
        public decimal? CostPriceRatio { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal? OrderedQuantity { get; set; }
        public decimal? TotalPrice { get; set; }
        public InventoryItem? InventoryItemFkNavigation { get; set; }
        public VendorOrderDetail? RequestForQuotationDetailFkNavigation { get; set; }
        public SalesQuotation? SalesQuotationFkNavigation { get; set; }

        public SalesQuotationDetail()
        {
        }

        public SalesQuotationDetail(int? salesQuotationFk, int? requestForQuotationDetailFk, long? inventoryItemFk, decimal? vendorCostPrice, decimal? costPriceRatio, decimal? costPrice, decimal? orderedQuantity, decimal? totalPrice, bool isActive) : this()
        {
            SalesQuotationFk = salesQuotationFk;
            RequestForQuotationDetailFk = requestForQuotationDetailFk;
            InventoryItemFk = inventoryItemFk;
            VendorCostPrice = vendorCostPrice;
            CostPriceRatio = costPriceRatio;
            CostPrice = costPrice;
            OrderedQuantity = orderedQuantity;
            TotalPrice = totalPrice;
            IsActive = isActive;
        }

        public static SalesQuotationDetail Create(int? salesQuotationFk, int? requestForQuotationDetailFk, long? inventoryItemFk, decimal? vendorCostPrice, decimal? costPriceRatio, decimal? costPrice, decimal? orderedQuantity, decimal? totalPrice, bool isActive)
        {

            return new SalesQuotationDetail(salesQuotationFk, requestForQuotationDetailFk, inventoryItemFk, vendorCostPrice, costPriceRatio, costPrice, orderedQuantity, totalPrice, isActive);
        }

        public void Update(int? salesQuotationFk, int? requestForQuotationDetailFk, long? inventoryItemFk, decimal? vendorCostPrice, decimal? costPriceRatio, decimal? costPrice, decimal? orderedQuantity, decimal? totalPrice, bool isActive)
        {
            SalesQuotationFk = salesQuotationFk;
            RequestForQuotationDetailFk = requestForQuotationDetailFk;
            InventoryItemFk = inventoryItemFk;
            VendorCostPrice = vendorCostPrice;
            CostPriceRatio = costPriceRatio;
            CostPrice = costPrice;
            OrderedQuantity = orderedQuantity;
            TotalPrice = totalPrice;
            IsActive = isActive;
        }
    }
}
