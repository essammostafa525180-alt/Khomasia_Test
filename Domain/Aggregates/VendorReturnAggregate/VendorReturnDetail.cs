using Domain.Aggregates.InventoryItemAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.VendorReturnAggregate
{
    public class VendorReturnDetail : AggregateRootEntityBase<int>
    {
        public int? VendorReturnFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? Quantity { get; set; }
        public int? ReturnReasonFk { get; set; }
        public InventoryItem? InventoryItemFkNavigation { get; set; }
        public ReturnReason? ReturnReasonFkNavigation { get; set; }
        public VendorReturn? VendorReturnFkNavigation { get; set; }

        private List<VendorReturnSerial> _vendorReturnSerials = new List<VendorReturnSerial>();
        public IReadOnlyCollection<VendorReturnSerial> VendorReturnSerials => _vendorReturnSerials;

        public VendorReturnDetail()
        {
        }

        public VendorReturnDetail(int? vendorReturnFk, long? inventoryItemFk, decimal? quantity, int? returnReasonFk, bool isActive) : this()
        {
            VendorReturnFk = vendorReturnFk;
            InventoryItemFk = inventoryItemFk;
            Quantity = quantity;
            ReturnReasonFk = returnReasonFk;
            IsActive = isActive;
        }

        public static VendorReturnDetail Create(int? vendorReturnFk, long? inventoryItemFk, decimal? quantity, int? returnReasonFk, bool isActive)
        {

            return new VendorReturnDetail(vendorReturnFk, inventoryItemFk, quantity, returnReasonFk, isActive);
        }

        public void Update(int? vendorReturnFk, long? inventoryItemFk, decimal? quantity, int? returnReasonFk, bool isActive)
        {
            VendorReturnFk = vendorReturnFk;
            InventoryItemFk = inventoryItemFk;
            Quantity = quantity;
            ReturnReasonFk = returnReasonFk;
            IsActive = isActive;
        }
    }
}
