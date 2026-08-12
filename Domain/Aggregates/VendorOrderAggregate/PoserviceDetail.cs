using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class PoserviceDetail : AggregateRootEntityBase<int>
    {
        public int? PoserviceFk { get; set; }
        public int? ServiceTypeFk { get; set; }
        public int? ServiceMainCategoryFk { get; set; }
        public int? ServiceCategoryFk { get; set; }
        public int? ServiceSubCategoryFk { get; set; }
        public int? ServiceFk { get; set; }
        public int? Quantity { get; set; }
        public decimal? CostPerService { get; set; }
        public decimal? TotalCost { get; set; }
        public int? ContractServiceId { get; set; }
        public PurchaseOrderService? PoserviceFkNavigation { get; set; }
        public ServiceCategory? ServiceCategoryFkNavigation { get; set; }
        public Service? ServiceFkNavigation { get; set; }
        public ServiceMainCategory? ServiceMainCategoryFkNavigation { get; set; }
        public ServiceSubCategory? ServiceSubCategoryFkNavigation { get; set; }
        public ServiceType? ServiceTypeFkNavigation { get; set; }

        public PoserviceDetail()
        {
        }

        public PoserviceDetail(int? poserviceFk, int? serviceTypeFk, int? serviceMainCategoryFk, int? serviceCategoryFk, int? serviceSubCategoryFk, int? serviceFk, int? quantity, decimal? costPerService, decimal? totalCost, int? contractServiceId, bool isActive) : this()
        {
            PoserviceFk = poserviceFk;
            ServiceTypeFk = serviceTypeFk;
            ServiceMainCategoryFk = serviceMainCategoryFk;
            ServiceCategoryFk = serviceCategoryFk;
            ServiceSubCategoryFk = serviceSubCategoryFk;
            ServiceFk = serviceFk;
            Quantity = quantity;
            CostPerService = costPerService;
            TotalCost = totalCost;
            ContractServiceId = contractServiceId;
            IsActive = isActive;
        }

        public static PoserviceDetail Create(int? poserviceFk, int? serviceTypeFk, int? serviceMainCategoryFk, int? serviceCategoryFk, int? serviceSubCategoryFk, int? serviceFk, int? quantity, decimal? costPerService, decimal? totalCost, int? contractServiceId, bool isActive)
        {

            return new PoserviceDetail(poserviceFk, serviceTypeFk, serviceMainCategoryFk, serviceCategoryFk, serviceSubCategoryFk, serviceFk, quantity, costPerService, totalCost, contractServiceId, isActive);
        }

        public void Update(int? poserviceFk, int? serviceTypeFk, int? serviceMainCategoryFk, int? serviceCategoryFk, int? serviceSubCategoryFk, int? serviceFk, int? quantity, decimal? costPerService, decimal? totalCost, int? contractServiceId, bool isActive)
        {
            PoserviceFk = poserviceFk;
            ServiceTypeFk = serviceTypeFk;
            ServiceMainCategoryFk = serviceMainCategoryFk;
            ServiceCategoryFk = serviceCategoryFk;
            ServiceSubCategoryFk = serviceSubCategoryFk;
            ServiceFk = serviceFk;
            Quantity = quantity;
            CostPerService = costPerService;
            TotalCost = totalCost;
            ContractServiceId = contractServiceId;
            IsActive = isActive;
        }
    }
}
