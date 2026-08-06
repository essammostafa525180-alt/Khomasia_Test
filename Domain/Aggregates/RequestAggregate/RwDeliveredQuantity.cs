using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.RequestAggregate
{
    public class RwDeliveredQuantity : AggregateRootEntityBase<int>
    {
        public int? RequestWdfk { get; set; }
        public decimal? DeliveredQuantity { get; set; }
        public decimal? ScrapedQuantity { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public bool? Axsynced { get; set; }
        public bool? IsReceived { get; set; }
        public decimal? MaintainableQuantity { get; set; }
        public string? DeliveredNumber { get; set; }
        public InventroyItemRequestWithdrawDetail? RequestWdfkNavigation { get; set; }

        private List<RequestWithdrawSerial> _requestWithdrawSerials = new List<RequestWithdrawSerial>();
        public IReadOnlyCollection<RequestWithdrawSerial> RequestWithdrawSerials => _requestWithdrawSerials;

        public RwDeliveredQuantity()
        {
        }

        public RwDeliveredQuantity(int? requestWdfk, decimal? deliveredQuantity, decimal? scrapedQuantity, DateTime? deliveredDate, bool? axsynced, bool? isReceived, decimal? maintainableQuantity, string? deliveredNumber, bool isActive) : this()
        {
            RequestWdfk = requestWdfk;
            DeliveredQuantity = deliveredQuantity;
            ScrapedQuantity = scrapedQuantity;
            DeliveredDate = deliveredDate;
            Axsynced = axsynced;
            IsReceived = isReceived;
            MaintainableQuantity = maintainableQuantity;
            DeliveredNumber = deliveredNumber;
            IsActive = isActive;
        }

        public static RwDeliveredQuantity Create(int? requestWdfk, decimal? deliveredQuantity, decimal? scrapedQuantity, DateTime? deliveredDate, bool? axsynced, bool? isReceived, decimal? maintainableQuantity, string? deliveredNumber, bool isActive)
        {

            return new RwDeliveredQuantity(requestWdfk, deliveredQuantity, scrapedQuantity, deliveredDate, axsynced, isReceived, maintainableQuantity, deliveredNumber, isActive);
        }

        public void Update(int? requestWdfk, decimal? deliveredQuantity, decimal? scrapedQuantity, DateTime? deliveredDate, bool? axsynced, bool? isReceived, decimal? maintainableQuantity, string? deliveredNumber, bool isActive)
        {
            RequestWdfk = requestWdfk;
            DeliveredQuantity = deliveredQuantity;
            ScrapedQuantity = scrapedQuantity;
            DeliveredDate = deliveredDate;
            Axsynced = axsynced;
            IsReceived = isReceived;
            MaintainableQuantity = maintainableQuantity;
            DeliveredNumber = deliveredNumber;
            IsActive = isActive;
        }
    }
}
