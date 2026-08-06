using Domain.Primitives;

namespace Domain.Entities
{
    public class ViewRequestStatus : AuditableEntityBase<int>
    {
        public int PurchaseRequestFk { get; private set; }
        public decimal? TotalRequestedQuantity { get; private set; }
        public decimal? TotalOrderedQuantity { get; private set; }
        public int RequestOrderStatusId { get; private set; }

        private ViewRequestStatus()
        {
        }

        public ViewRequestStatus(int purchaseRequestFk, decimal? totalRequestedQuantity, decimal? totalOrderedQuantity, int requestOrderStatusId, bool isActive) : this()
        {
            PurchaseRequestFk = purchaseRequestFk;
            TotalRequestedQuantity = totalRequestedQuantity;
            TotalOrderedQuantity = totalOrderedQuantity;
            RequestOrderStatusId = requestOrderStatusId;
            IsActive = isActive;
        }

        public static ViewRequestStatus Create(int purchaseRequestFk, decimal? totalRequestedQuantity, decimal? totalOrderedQuantity, int requestOrderStatusId, bool isActive)
        {

            return new ViewRequestStatus(purchaseRequestFk, totalRequestedQuantity, totalOrderedQuantity, requestOrderStatusId, isActive);
        }

        public void Update(int purchaseRequestFk, decimal? totalRequestedQuantity, decimal? totalOrderedQuantity, int requestOrderStatusId, bool isActive)
        {
            PurchaseRequestFk = purchaseRequestFk;
            TotalRequestedQuantity = totalRequestedQuantity;
            TotalOrderedQuantity = totalOrderedQuantity;
            RequestOrderStatusId = requestOrderStatusId;
            IsActive = isActive;
        }
    }
}
