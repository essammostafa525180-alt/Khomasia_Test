using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;

namespace Domain.Aggregates.RequestAggregate
{
    public class RequestWithdrawSerial : AggregateRootEntityBase<int>
    {
        public int? RequestWithdrawFk { get; set; }
        public int? RequestWithdrawDetailFk { get; set; }
        public int? RwDeliveredQuantityFk { get; set; }
        public int? InventoryItemSerialFk { get; set; }
        public InventoryItemSerial? InventoryItemSerialFkNavigation { get; set; }
        public InventroyItemRequestWithdrawDetail? RequestWithdrawDetailFkNavigation { get; set; }
        public InventroyItemRequestWithdraw? RequestWithdrawFkNavigation { get; set; }
        public RwDeliveredQuantity? RwDeliveredQuantityFkNavigation { get; set; }

        public RequestWithdrawSerial()
        {
        }

        public RequestWithdrawSerial(int? requestWithdrawFk, int? requestWithdrawDetailFk, int? rwDeliveredQuantityFk, int? inventoryItemSerialFk, bool isActive) : this()
        {
            RequestWithdrawFk = requestWithdrawFk;
            RequestWithdrawDetailFk = requestWithdrawDetailFk;
            RwDeliveredQuantityFk = rwDeliveredQuantityFk;
            InventoryItemSerialFk = inventoryItemSerialFk;
            IsActive = isActive;
        }

        public static RequestWithdrawSerial Create(int? requestWithdrawFk, int? requestWithdrawDetailFk, int? rwDeliveredQuantityFk, int? inventoryItemSerialFk, bool isActive)
        {

            return new RequestWithdrawSerial(requestWithdrawFk, requestWithdrawDetailFk, rwDeliveredQuantityFk, inventoryItemSerialFk, isActive);
        }

        public void Update(int? requestWithdrawFk, int? requestWithdrawDetailFk, int? rwDeliveredQuantityFk, int? inventoryItemSerialFk, bool isActive)
        {
            RequestWithdrawFk = requestWithdrawFk;
            RequestWithdrawDetailFk = requestWithdrawDetailFk;
            RwDeliveredQuantityFk = rwDeliveredQuantityFk;
            InventoryItemSerialFk = inventoryItemSerialFk;
            IsActive = isActive;
        }
    }
}
