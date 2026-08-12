using Domain.Aggregates.InventoryItemAggregate;
using Domain.Aggregates.VendorReturnAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ReturnReason : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public int? IntegrationId { get; private set; }

        private List<InventoryItemReturnBatchSerial> _inventoryItemReturnBatchSerials = new List<InventoryItemReturnBatchSerial>();
        public IReadOnlyCollection<InventoryItemReturnBatchSerial> InventoryItemReturnBatchSerials => _inventoryItemReturnBatchSerials;

        private List<InventoryItemReturnBatch> _inventoryItemReturnBatches = new List<InventoryItemReturnBatch>();
        public IReadOnlyCollection<InventoryItemReturnBatch> InventoryItemReturnBatches => _inventoryItemReturnBatches;

        private List<InventoryItemReturnDetail> _inventoryItemReturnDetails = new List<InventoryItemReturnDetail>();
        public IReadOnlyCollection<InventoryItemReturnDetail> InventoryItemReturnDetails => _inventoryItemReturnDetails;

        private List<VendorReturnDetailBatchSerial> _vendorReturnDetailBatchSerials = new List<VendorReturnDetailBatchSerial>();
        public IReadOnlyCollection<VendorReturnDetailBatchSerial> VendorReturnDetailBatchSerials => _vendorReturnDetailBatchSerials;

        private List<VendorReturnDetailBatch> _vendorReturnDetailBatches = new List<VendorReturnDetailBatch>();
        public IReadOnlyCollection<VendorReturnDetailBatch> VendorReturnDetailBatches => _vendorReturnDetailBatches;

        private List<VendorReturnDetail> _vendorReturnDetails = new List<VendorReturnDetail>();
        public IReadOnlyCollection<VendorReturnDetail> VendorReturnDetails => _vendorReturnDetails;

        private ReturnReason()
        {
        }

        public ReturnReason(string? name, string? nameAr, int? integrationId, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IntegrationId = integrationId;
            IsActive = isActive;
        }

        public static ReturnReason Create(string? name, string? nameAr, int? integrationId, bool isActive)
        {

            return new ReturnReason(name, nameAr, integrationId, isActive);
        }

        public void Update(string? name, string? nameAr, int? integrationId, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IntegrationId = integrationId;
            IsActive = isActive;
        }
    }
}
