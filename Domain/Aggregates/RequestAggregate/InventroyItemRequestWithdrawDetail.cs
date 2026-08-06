using Domain.Aggregates.InventoryItemAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.RequestAggregate
{
    public class InventroyItemRequestWithdrawDetail : AggregateRootEntityBase<int>
    {
        public int? RequestWfk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? RequestedQuantity { get; set; }
        public decimal? PickedQuantity { get; set; }
        public decimal? DeliveredQuantity { get; set; }
        public decimal? ReturnedQuantity { get; set; }
        public decimal? ScrapedQuantity { get; set; }
        public int? RequestLineItemStatusFk { get; set; }
        public int? FromSerial { get; set; }
        public int? ToSerial { get; set; }
        public int? IntegrationId { get; set; }
        public bool? IsSync { get; set; }
        public decimal? LastPurchasePrice { get; set; }
        public decimal? AvgCost { get; set; }
        public InventoryItem? InventoryItemFkNavigation { get; set; }
        public RequestLineItemStatus? RequestLineItemStatusFkNavigation { get; set; }
        public InventroyItemRequestWithdraw? RequestWfkNavigation { get; set; }

        private List<RequestWithdrawSerial> _requestWithdrawSerials = new List<RequestWithdrawSerial>();
        public IReadOnlyCollection<RequestWithdrawSerial> RequestWithdrawSerials => _requestWithdrawSerials;

        private List<RwDeliveredBatch> _rwDeliveredBatches = new List<RwDeliveredBatch>();
        public IReadOnlyCollection<RwDeliveredBatch> RwDeliveredBatches => _rwDeliveredBatches;

        private List<RwDeliveredQuantity> _rwDeliveredQuantities = new List<RwDeliveredQuantity>();
        public IReadOnlyCollection<RwDeliveredQuantity> RwDeliveredQuantities => _rwDeliveredQuantities;

        private List<RwPickedQuantity> _rwPickedQuantities = new List<RwPickedQuantity>();
        public IReadOnlyCollection<RwPickedQuantity> RwPickedQuantities => _rwPickedQuantities;

        public InventroyItemRequestWithdrawDetail()
        {
        }

        public InventroyItemRequestWithdrawDetail(int? requestWfk, long? inventoryItemFk, decimal? requestedQuantity, decimal? pickedQuantity, decimal? deliveredQuantity, decimal? returnedQuantity, decimal? scrapedQuantity, int? requestLineItemStatusFk, int? fromSerial, int? toSerial, int? integrationId, bool? isSync, decimal? lastPurchasePrice, decimal? avgCost, bool isActive) : this()
        {
            RequestWfk = requestWfk;
            InventoryItemFk = inventoryItemFk;
            RequestedQuantity = requestedQuantity;
            PickedQuantity = pickedQuantity;
            DeliveredQuantity = deliveredQuantity;
            ReturnedQuantity = returnedQuantity;
            ScrapedQuantity = scrapedQuantity;
            RequestLineItemStatusFk = requestLineItemStatusFk;
            FromSerial = fromSerial;
            ToSerial = toSerial;
            IntegrationId = integrationId;
            IsSync = isSync;
            LastPurchasePrice = lastPurchasePrice;
            AvgCost = avgCost;
            IsActive = isActive;
        }

        public static InventroyItemRequestWithdrawDetail Create(int? requestWfk, long? inventoryItemFk, decimal? requestedQuantity, decimal? pickedQuantity, decimal? deliveredQuantity, decimal? returnedQuantity, decimal? scrapedQuantity, int? requestLineItemStatusFk, int? fromSerial, int? toSerial, int? integrationId, bool? isSync, decimal? lastPurchasePrice, decimal? avgCost, bool isActive)
        {

            return new InventroyItemRequestWithdrawDetail(requestWfk, inventoryItemFk, requestedQuantity, pickedQuantity, deliveredQuantity, returnedQuantity, scrapedQuantity, requestLineItemStatusFk, fromSerial, toSerial, integrationId, isSync, lastPurchasePrice, avgCost, isActive);
        }

        public void Update(int? requestWfk, long? inventoryItemFk, decimal? requestedQuantity, decimal? pickedQuantity, decimal? deliveredQuantity, decimal? returnedQuantity, decimal? scrapedQuantity, int? requestLineItemStatusFk, int? fromSerial, int? toSerial, int? integrationId, bool? isSync, decimal? lastPurchasePrice, decimal? avgCost, bool isActive)
        {
            RequestWfk = requestWfk;
            InventoryItemFk = inventoryItemFk;
            RequestedQuantity = requestedQuantity;
            PickedQuantity = pickedQuantity;
            DeliveredQuantity = deliveredQuantity;
            ReturnedQuantity = returnedQuantity;
            ScrapedQuantity = scrapedQuantity;
            RequestLineItemStatusFk = requestLineItemStatusFk;
            FromSerial = fromSerial;
            ToSerial = toSerial;
            IntegrationId = integrationId;
            IsSync = isSync;
            LastPurchasePrice = lastPurchasePrice;
            AvgCost = avgCost;
            IsActive = isActive;
        }
    }
}
