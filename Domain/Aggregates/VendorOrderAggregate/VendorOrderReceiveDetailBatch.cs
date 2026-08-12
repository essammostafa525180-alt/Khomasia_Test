using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class VendorOrderReceiveDetailBatch : AggregateRootEntityBase<int>
    {
        public int? VendorOrderReceiveDetailFk { get; set; }
        public int? ShelfFk { get; set; }
        public string? BatchNumber { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? ReturnedQuantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? ProductionDate { get; set; }
        public Shelf? ShelfFkNavigation { get; set; }
        public VendorOrderReceiveDetail? VendorOrderReceiveDetailFkNavigation { get; set; }

        private List<VendorOrderReceiveDetailBatchSerial> _vendorOrderReceiveDetailBatchSerials = new List<VendorOrderReceiveDetailBatchSerial>();
        public IReadOnlyCollection<VendorOrderReceiveDetailBatchSerial> VendorOrderReceiveDetailBatchSerials => _vendorOrderReceiveDetailBatchSerials;

        public VendorOrderReceiveDetailBatch()
        {
        }

        public VendorOrderReceiveDetailBatch(int? vendorOrderReceiveDetailFk, int? shelfFk, string? batchNumber, decimal? quantity, decimal? returnedQuantity, DateTime? expiryDate, DateTime? productionDate, bool isActive) : this()
        {
            VendorOrderReceiveDetailFk = vendorOrderReceiveDetailFk;
            ShelfFk = shelfFk;
            BatchNumber = batchNumber;
            Quantity = quantity;
            ReturnedQuantity = returnedQuantity;
            ExpiryDate = expiryDate;
            ProductionDate = productionDate;
            IsActive = isActive;
        }

        public static VendorOrderReceiveDetailBatch Create(int? vendorOrderReceiveDetailFk, int? shelfFk, string? batchNumber, decimal? quantity, decimal? returnedQuantity, DateTime? expiryDate, DateTime? productionDate, bool isActive)
        {

            return new VendorOrderReceiveDetailBatch(vendorOrderReceiveDetailFk, shelfFk, batchNumber, quantity, returnedQuantity, expiryDate, productionDate, isActive);
        }

        public void Update(int? vendorOrderReceiveDetailFk, int? shelfFk, string? batchNumber, decimal? quantity, decimal? returnedQuantity, DateTime? expiryDate, DateTime? productionDate, bool isActive)
        {
            VendorOrderReceiveDetailFk = vendorOrderReceiveDetailFk;
            ShelfFk = shelfFk;
            BatchNumber = batchNumber;
            Quantity = quantity;
            ReturnedQuantity = returnedQuantity;
            ExpiryDate = expiryDate;
            ProductionDate = productionDate;
            IsActive = isActive;
        }
    }
}
