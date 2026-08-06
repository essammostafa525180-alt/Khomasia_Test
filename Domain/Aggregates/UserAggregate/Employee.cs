using Domain.Aggregates.AssetAggregate;
using Domain.Aggregates.RequestAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.UserAggregate
{
    public class Employee : AggregateRootEntityBase<int>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? EmployeeJobFk { get; set; }
        public EmployeeJob? EmployeeJobFkNavigation { get; set; }

        private List<AssetItemMove> _assetItemMoveEmployeeFkNavigations = new List<AssetItemMove>();
        public IReadOnlyCollection<AssetItemMove> AssetItemMoveEmployeeFkNavigations => _assetItemMoveEmployeeFkNavigations;

        private List<AssetItemMove> _assetItemMoveManagerApprovedFkNavigations = new List<AssetItemMove>();
        public IReadOnlyCollection<AssetItemMove> AssetItemMoveManagerApprovedFkNavigations => _assetItemMoveManagerApprovedFkNavigations;

        private List<AssetItemMove> _assetItemMoveOwnerApprovedFkNavigations = new List<AssetItemMove>();
        public IReadOnlyCollection<AssetItemMove> AssetItemMoveOwnerApprovedFkNavigations => _assetItemMoveOwnerApprovedFkNavigations;

        private List<AssetItem> _assetItems = new List<AssetItem>();
        public IReadOnlyCollection<AssetItem> AssetItems => _assetItems;

        private List<InventroyItemRequestWithdraw> _inventroyItemRequestWithdraws = new List<InventroyItemRequestWithdraw>();
        public IReadOnlyCollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdraws => _inventroyItemRequestWithdraws;

        private List<User> _users = new List<User>();
        public IReadOnlyCollection<User> Users => _users;

        public Employee()
        {
        }

        public Employee(string? code, string? name, string? nameAr, int? employeeJobFk, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            EmployeeJobFk = employeeJobFk;
            IsActive = isActive;
        }

        public static Employee Create(string? code, string? name, string? nameAr, int? employeeJobFk, bool isActive)
        {

            return new Employee(code, name, nameAr, employeeJobFk, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, int? employeeJobFk, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            EmployeeJobFk = employeeJobFk;
            IsActive = isActive;
        }
    }
}
