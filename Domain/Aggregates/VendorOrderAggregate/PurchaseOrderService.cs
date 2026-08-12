using Domain.Aggregates.CompanyAggregate;
using Domain.Aggregates.LocationAggregate;
using Domain.Aggregates.VendorAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class PurchaseOrderService : AggregateRootEntityBase<int>
    {
        public int? OrderScreenFk { get; set; }
        public int? PoserviceTypeFk { get; set; }
        public int? VendorOrderTypeFk { get; set; }
        public int? VendorFk { get; set; }
        public int? Prfk { get; set; }
        public string? OrderNo { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? OrderByUserFk { get; set; }
        public int? ProjectFk { get; set; }
        public int? LocationFk { get; set; }
        public int? ServiceMainCategoryFk { get; set; }
        public int? ScopeFk { get; set; }
        public int? VendorOrderStatusFk { get; set; }
        public int? PaymentTermFk { get; set; }
        public string? PaymentTerms { get; set; }
        public bool? IsApproved { get; set; }
        public int? Duration { get; set; }
        public int? CompanyFk { get; set; }
        public int? ContractId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ContractCode { get; set; }
        public decimal? TotalCost { get; set; }
        public string? Description { get; set; }
        public int? InventoryItemBudgetFk { get; set; }
        public Company? CompanyFkNavigation { get; set; }
        public Location? LocationFkNavigation { get; set; }
        public VendorOrderScreen? OrderScreenFkNavigation { get; set; }
        public PaymentTerm? PaymentTermFkNavigation { get; set; }
        public PoserviceType? PoserviceTypeFkNavigation { get; set; }
        public PurchaseOrderService? PrfkNavigation { get; set; }
        public Project? ProjectFkNavigation { get; set; }
        public Scope? ScopeFkNavigation { get; set; }
        public ServiceMainCategory? ServiceMainCategoryFkNavigation { get; set; }
        public Vendor? VendorFkNavigation { get; set; }
        public VendorOrderStatus? VendorOrderStatusFkNavigation { get; set; }
        public VendorOrderType? VendorOrderTypeFkNavigation { get; set; }

        private List<ApprovalMatrix> _approvalMatrices = new List<ApprovalMatrix>();
        public IReadOnlyCollection<ApprovalMatrix> ApprovalMatrices => _approvalMatrices;

        private List<PurchaseOrderService> _inversePrfkNavigation = new List<PurchaseOrderService>();
        public IReadOnlyCollection<PurchaseOrderService> InversePrfkNavigation => _inversePrfkNavigation;

        private List<PoserviceAsset> _poserviceAssets = new List<PoserviceAsset>();
        public IReadOnlyCollection<PoserviceAsset> PoserviceAssets => _poserviceAssets;

        private List<PoserviceDetail> _poserviceDetails = new List<PoserviceDetail>();
        public IReadOnlyCollection<PoserviceDetail> PoserviceDetails => _poserviceDetails;

        private List<PoserviceOutsource> _poserviceOutsources = new List<PoserviceOutsource>();
        public IReadOnlyCollection<PoserviceOutsource> PoserviceOutsources => _poserviceOutsources;

        private List<PoserviceRecomendedResource> _poserviceRecomendedResources = new List<PoserviceRecomendedResource>();
        public IReadOnlyCollection<PoserviceRecomendedResource> PoserviceRecomendedResources => _poserviceRecomendedResources;

        private List<PurchaseOrderServiceAttachment> _purchaseOrderServiceAttachments = new List<PurchaseOrderServiceAttachment>();
        public IReadOnlyCollection<PurchaseOrderServiceAttachment> PurchaseOrderServiceAttachments => _purchaseOrderServiceAttachments;

        public PurchaseOrderService()
        {
        }

        public PurchaseOrderService(int? orderScreenFk, int? poserviceTypeFk, int? vendorOrderTypeFk, int? vendorFk, int? prfk, string? orderNo, DateTime? requestDate, DateTime? orderDate, int? orderByUserFk, int? projectFk, int? locationFk, int? serviceMainCategoryFk, int? scopeFk, int? vendorOrderStatusFk, int? paymentTermFk, string? paymentTerms, bool? isApproved, int? duration, int? companyFk, int? contractId, DateTime? startDate, DateTime? endDate, string? contractCode, decimal? totalCost, string? description, int? inventoryItemBudgetFk, bool isActive) : this()
        {
            OrderScreenFk = orderScreenFk;
            PoserviceTypeFk = poserviceTypeFk;
            VendorOrderTypeFk = vendorOrderTypeFk;
            VendorFk = vendorFk;
            Prfk = prfk;
            OrderNo = orderNo;
            RequestDate = requestDate;
            OrderDate = orderDate;
            OrderByUserFk = orderByUserFk;
            ProjectFk = projectFk;
            LocationFk = locationFk;
            ServiceMainCategoryFk = serviceMainCategoryFk;
            ScopeFk = scopeFk;
            VendorOrderStatusFk = vendorOrderStatusFk;
            PaymentTermFk = paymentTermFk;
            PaymentTerms = paymentTerms;
            IsApproved = isApproved;
            Duration = duration;
            CompanyFk = companyFk;
            ContractId = contractId;
            StartDate = startDate;
            EndDate = endDate;
            ContractCode = contractCode;
            TotalCost = totalCost;
            Description = description;
            InventoryItemBudgetFk = inventoryItemBudgetFk;
            IsActive = isActive;
        }

        public static PurchaseOrderService Create(int? orderScreenFk, int? poserviceTypeFk, int? vendorOrderTypeFk, int? vendorFk, int? prfk, string? orderNo, DateTime? requestDate, DateTime? orderDate, int? orderByUserFk, int? projectFk, int? locationFk, int? serviceMainCategoryFk, int? scopeFk, int? vendorOrderStatusFk, int? paymentTermFk, string? paymentTerms, bool? isApproved, int? duration, int? companyFk, int? contractId, DateTime? startDate, DateTime? endDate, string? contractCode, decimal? totalCost, string? description, int? inventoryItemBudgetFk, bool isActive)
        {

            return new PurchaseOrderService(orderScreenFk, poserviceTypeFk, vendorOrderTypeFk, vendorFk, prfk, orderNo, requestDate, orderDate, orderByUserFk, projectFk, locationFk, serviceMainCategoryFk, scopeFk, vendorOrderStatusFk, paymentTermFk, paymentTerms, isApproved, duration, companyFk, contractId, startDate, endDate, contractCode, totalCost, description, inventoryItemBudgetFk, isActive);
        }

        public void Update(int? orderScreenFk, int? poserviceTypeFk, int? vendorOrderTypeFk, int? vendorFk, int? prfk, string? orderNo, DateTime? requestDate, DateTime? orderDate, int? orderByUserFk, int? projectFk, int? locationFk, int? serviceMainCategoryFk, int? scopeFk, int? vendorOrderStatusFk, int? paymentTermFk, string? paymentTerms, bool? isApproved, int? duration, int? companyFk, int? contractId, DateTime? startDate, DateTime? endDate, string? contractCode, decimal? totalCost, string? description, int? inventoryItemBudgetFk, bool isActive)
        {
            OrderScreenFk = orderScreenFk;
            PoserviceTypeFk = poserviceTypeFk;
            VendorOrderTypeFk = vendorOrderTypeFk;
            VendorFk = vendorFk;
            Prfk = prfk;
            OrderNo = orderNo;
            RequestDate = requestDate;
            OrderDate = orderDate;
            OrderByUserFk = orderByUserFk;
            ProjectFk = projectFk;
            LocationFk = locationFk;
            ServiceMainCategoryFk = serviceMainCategoryFk;
            ScopeFk = scopeFk;
            VendorOrderStatusFk = vendorOrderStatusFk;
            PaymentTermFk = paymentTermFk;
            PaymentTerms = paymentTerms;
            IsApproved = isApproved;
            Duration = duration;
            CompanyFk = companyFk;
            ContractId = contractId;
            StartDate = startDate;
            EndDate = endDate;
            ContractCode = contractCode;
            TotalCost = totalCost;
            Description = description;
            InventoryItemBudgetFk = inventoryItemBudgetFk;
            IsActive = isActive;
        }
    }
}
