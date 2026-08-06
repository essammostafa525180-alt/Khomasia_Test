using Domain.Aggregates.RequestAggregate;
using Domain.Aggregates.UserAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.InventoryItemAggregate
{
    public class InventoryItemReturn : AggregateRootEntityBase<int>
    {
        public int? RequestWithdrawFk { get; set; }
        public string? ReturnNo { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int? ReturnedByFk { get; set; }
        public string? ReturnedBy { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }
        public int? ItemReturnStatusFk { get; set; }
        public bool? IsAprove { get; set; }
        public bool? Axsynced { get; set; }
        public int? SourceId { get; set; }
        public User? CreatedByNavigation { get; set; }
        public ReturnStatus? ItemReturnStatusFkNavigation { get; set; }
        public User? LastUpdatedByNavigation { get; set; }
        public InventroyItemRequestWithdraw? RequestWithdrawFkNavigation { get; set; }
        public User? ReturnedByFkNavigation { get; set; }

        private List<InventoryItemReturnAttachment> _inventoryItemReturnAttachments = new List<InventoryItemReturnAttachment>();
        public IReadOnlyCollection<InventoryItemReturnAttachment> InventoryItemReturnAttachments => _inventoryItemReturnAttachments;

        private List<InventoryItemReturnDetail> _inventoryItemReturnDetails = new List<InventoryItemReturnDetail>();
        public IReadOnlyCollection<InventoryItemReturnDetail> InventoryItemReturnDetails => _inventoryItemReturnDetails;

        private List<InventoryItemReturnSerial> _inventoryItemReturnSerials = new List<InventoryItemReturnSerial>();
        public IReadOnlyCollection<InventoryItemReturnSerial> InventoryItemReturnSerials => _inventoryItemReturnSerials;

        public InventoryItemReturn()
        {
        }

        public InventoryItemReturn(int? requestWithdrawFk, string? returnNo, DateTime? returnDate, int? returnedByFk, string? returnedBy, string? descriptionEn, string? descriptionAr, int? itemReturnStatusFk, bool? isAprove, bool? axsynced, int? sourceId, bool isActive) : this()
        {
            RequestWithdrawFk = requestWithdrawFk;
            ReturnNo = returnNo;
            ReturnDate = returnDate;
            ReturnedByFk = returnedByFk;
            ReturnedBy = returnedBy;
            DescriptionEn = descriptionEn;
            DescriptionAr = descriptionAr;
            ItemReturnStatusFk = itemReturnStatusFk;
            IsAprove = isAprove;
            Axsynced = axsynced;
            SourceId = sourceId;
            IsActive = isActive;
        }

        public static InventoryItemReturn Create(int? requestWithdrawFk, string? returnNo, DateTime? returnDate, int? returnedByFk, string? returnedBy, string? descriptionEn, string? descriptionAr, int? itemReturnStatusFk, bool? isAprove, bool? axsynced, int? sourceId, bool isActive)
        {

            return new InventoryItemReturn(requestWithdrawFk, returnNo, returnDate, returnedByFk, returnedBy, descriptionEn, descriptionAr, itemReturnStatusFk, isAprove, axsynced, sourceId, isActive);
        }

        public void Update(int? requestWithdrawFk, string? returnNo, DateTime? returnDate, int? returnedByFk, string? returnedBy, string? descriptionEn, string? descriptionAr, int? itemReturnStatusFk, bool? isAprove, bool? axsynced, int? sourceId, bool isActive)
        {
            RequestWithdrawFk = requestWithdrawFk;
            ReturnNo = returnNo;
            ReturnDate = returnDate;
            ReturnedByFk = returnedByFk;
            ReturnedBy = returnedBy;
            DescriptionEn = descriptionEn;
            DescriptionAr = descriptionAr;
            ItemReturnStatusFk = itemReturnStatusFk;
            IsAprove = isAprove;
            Axsynced = axsynced;
            SourceId = sourceId;
            IsActive = isActive;
        }
    }
}
