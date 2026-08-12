using Domain.Primitives;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class VendorOrderQualityDetailBatch : AggregateRootEntityBase<int>
    {
        public int? VendorOrderQualityDetailFk { get; set; }
        public int? ShelfFk { get; set; }
        public string? BatchNumber { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? ProductionDate { get; set; }
        public VendorOrderQualityDetail? VendorOrderQualityDetailFkNavigation { get; set; }

        public VendorOrderQualityDetailBatch()
        {
        }

        public VendorOrderQualityDetailBatch(int? vendorOrderQualityDetailFk, int? shelfFk, string? batchNumber, decimal? quantity, DateTime? expiryDate, DateTime? productionDate, bool isActive) : this()
        {
            VendorOrderQualityDetailFk = vendorOrderQualityDetailFk;
            ShelfFk = shelfFk;
            BatchNumber = batchNumber;
            Quantity = quantity;
            ExpiryDate = expiryDate;
            ProductionDate = productionDate;
            IsActive = isActive;
        }

        public static VendorOrderQualityDetailBatch Create(int? vendorOrderQualityDetailFk, int? shelfFk, string? batchNumber, decimal? quantity, DateTime? expiryDate, DateTime? productionDate, bool isActive)
        {

            return new VendorOrderQualityDetailBatch(vendorOrderQualityDetailFk, shelfFk, batchNumber, quantity, expiryDate, productionDate, isActive);
        }

        public void Update(int? vendorOrderQualityDetailFk, int? shelfFk, string? batchNumber, decimal? quantity, DateTime? expiryDate, DateTime? productionDate, bool isActive)
        {
            VendorOrderQualityDetailFk = vendorOrderQualityDetailFk;
            ShelfFk = shelfFk;
            BatchNumber = batchNumber;
            Quantity = quantity;
            ExpiryDate = expiryDate;
            ProductionDate = productionDate;
            IsActive = isActive;
        }
    }
}
