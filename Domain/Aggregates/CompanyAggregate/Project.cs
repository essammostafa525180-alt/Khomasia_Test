using Domain.Aggregates.AssetAggregate;
using Domain.Aggregates.InventoryItemAggregate;
using Domain.Aggregates.LocationAggregate;
using Domain.Aggregates.RequestAggregate;
using Domain.Aggregates.StoreAggregate;
using Domain.Aggregates.VehicleAggregate;
using Domain.Aggregates.VendorOrderAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.CompanyAggregate
{
    public class Project : AggregateRootEntityBase<int>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? CompanyFk { get; set; }
        public int? StoreFk { get; set; }
        public int? CustomerFk { get; set; }
        public Company? CompanyFkNavigation { get; set; }
        public Store? StoreFkNavigation { get; set; }

        private List<ApprovalMatrixConfig> _approvalMatrixConfigs = new List<ApprovalMatrixConfig>();
        public IReadOnlyCollection<ApprovalMatrixConfig> ApprovalMatrixConfigs => _approvalMatrixConfigs;

        private List<AssetItemMove> _assetItemMoveFromProjectFkNavigations = new List<AssetItemMove>();
        public IReadOnlyCollection<AssetItemMove> AssetItemMoveFromProjectFkNavigations => _assetItemMoveFromProjectFkNavigations;

        private List<AssetItemMove> _assetItemMoveToProjectFkNavigations = new List<AssetItemMove>();
        public IReadOnlyCollection<AssetItemMove> AssetItemMoveToProjectFkNavigations => _assetItemMoveToProjectFkNavigations;

        private List<AssetItem> _assetItems = new List<AssetItem>();
        public IReadOnlyCollection<AssetItem> AssetItems => _assetItems;

        private List<Asset> _assets = new List<Asset>();
        public IReadOnlyCollection<Asset> Assets => _assets;

        private List<City> _cities = new List<City>();
        public IReadOnlyCollection<City> Cities => _cities;

        private List<InventoryItemBudget> _inventoryItemBudgets = new List<InventoryItemBudget>();
        public IReadOnlyCollection<InventoryItemBudget> InventoryItemBudgets => _inventoryItemBudgets;

        private List<InventroyItemRequestWithdraw> _inventroyItemRequestWithdraws = new List<InventroyItemRequestWithdraw>();
        public IReadOnlyCollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdraws => _inventroyItemRequestWithdraws;

        private List<Line> _lines = new List<Line>();
        public IReadOnlyCollection<Line> Lines => _lines;

        private List<Location> _locations = new List<Location>();
        public IReadOnlyCollection<Location> Locations => _locations;

        private List<PurchaseOrderService> _purchaseOrderServices = new List<PurchaseOrderService>();
        public IReadOnlyCollection<PurchaseOrderService> PurchaseOrderServices => _purchaseOrderServices;

        private List<Vehicle> _vehicles = new List<Vehicle>();
        public IReadOnlyCollection<Vehicle> Vehicles => _vehicles;

        private List<VendorOrder> _vendorOrders = new List<VendorOrder>();
        public IReadOnlyCollection<VendorOrder> VendorOrders => _vendorOrders;

        public Project()
        {
        }

        public Project(string? code, string? name, string? nameAr, int? companyFk, int? storeFk, int? customerFk, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            CompanyFk = companyFk;
            StoreFk = storeFk;
            CustomerFk = customerFk;
            IsActive = isActive;
        }

        public static Project Create(string? code, string? name, string? nameAr, int? companyFk, int? storeFk, int? customerFk, bool isActive)
        {

            return new Project(code, name, nameAr, companyFk, storeFk, customerFk, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, int? companyFk, int? storeFk, int? customerFk, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            CompanyFk = companyFk;
            StoreFk = storeFk;
            CustomerFk = customerFk;
            IsActive = isActive;
        }
    }
}
