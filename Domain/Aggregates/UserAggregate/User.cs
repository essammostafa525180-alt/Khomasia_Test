using Domain.Aggregates.AuditAggregate;
using Domain.Aggregates.InventoryItemAggregate;
using Domain.Aggregates.RequestAggregate;
using Domain.Aggregates.SalesAggregate;
using Domain.Aggregates.SecurityAggregate;
using Domain.Aggregates.StoreAggregate;
using Domain.Aggregates.VendorOrderAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.UserAggregate
{
    public class User : AggregateRootEntityBase<int>
    {
        public DateTime? UpdatedOn { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? UserId { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? Contact { get; set; }
        public bool? Active { get; set; }
        public int? Ouid { get; set; }
        public string? NameAr { get; set; }
        public int? BranchId { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool? ForcePasswordChange { get; set; }
        public int? EmployeeId { get; set; }
        public int? MaxDiscount { get; set; }
        public DateTime? PasswordCreationDate { get; set; }
        public string? FullName { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public int? AdUserId { get; set; }
        public bool? IsPda { get; set; }
        public int? SingleSession { get; set; }
        public byte[] Timestamp { get; set; }
        public AdUser? AdUser { get; set; }
        public Employee? Employee { get; set; }
        public Ou? Ou { get; set; }

        private List<ApprovalMatrixConfigDetail> _approvalMatrixConfigDetails = new List<ApprovalMatrixConfigDetail>();
        public IReadOnlyCollection<ApprovalMatrixConfigDetail> ApprovalMatrixConfigDetails => _approvalMatrixConfigDetails;

        private List<ApprovalMatrixDetail> _approvalMatrixDetails = new List<ApprovalMatrixDetail>();
        public IReadOnlyCollection<ApprovalMatrixDetail> ApprovalMatrixDetails => _approvalMatrixDetails;

        private List<AuditTrail> _auditTrails = new List<AuditTrail>();
        public IReadOnlyCollection<AuditTrail> AuditTrails => _auditTrails;

        private List<InventoryItemReturn> _inventoryItemReturnCreatedByNavigations = new List<InventoryItemReturn>();
        public IReadOnlyCollection<InventoryItemReturn> InventoryItemReturnCreatedByNavigations => _inventoryItemReturnCreatedByNavigations;

        private List<InventoryItemReturn> _inventoryItemReturnLastUpdatedByNavigations = new List<InventoryItemReturn>();
        public IReadOnlyCollection<InventoryItemReturn> InventoryItemReturnLastUpdatedByNavigations => _inventoryItemReturnLastUpdatedByNavigations;

        private List<InventoryItemReturn> _inventoryItemReturnReturnedByFkNavigations = new List<InventoryItemReturn>();
        public IReadOnlyCollection<InventoryItemReturn> InventoryItemReturnReturnedByFkNavigations => _inventoryItemReturnReturnedByFkNavigations;

        private List<InventroyItemRequestWithdraw> _inventroyItemRequestWithdrawAssignedToUserFkNavigations = new List<InventroyItemRequestWithdraw>();
        public IReadOnlyCollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdrawAssignedToUserFkNavigations => _inventroyItemRequestWithdrawAssignedToUserFkNavigations;

        private List<InventroyItemRequestWithdraw> _inventroyItemRequestWithdrawCreatedByNavigations = new List<InventroyItemRequestWithdraw>();
        public IReadOnlyCollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdrawCreatedByNavigations => _inventroyItemRequestWithdrawCreatedByNavigations;

        private List<InventroyItemRequestWithdraw> _inventroyItemRequestWithdrawLastUpdatedByNavigations = new List<InventroyItemRequestWithdraw>();
        public IReadOnlyCollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdrawLastUpdatedByNavigations => _inventroyItemRequestWithdrawLastUpdatedByNavigations;

        private List<InventroyItemRequestWithdraw> _inventroyItemRequestWithdrawRequestedByFkNavigations = new List<InventroyItemRequestWithdraw>();
        public IReadOnlyCollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdrawRequestedByFkNavigations => _inventroyItemRequestWithdrawRequestedByFkNavigations;

        private List<Pruser> _prusers = new List<Pruser>();
        public IReadOnlyCollection<Pruser> Prusers => _prusers;

        private List<SalesInvoice> _salesInvoices = new List<SalesInvoice>();
        public IReadOnlyCollection<SalesInvoice> SalesInvoices => _salesInvoices;

        private List<SecUserModelAtrribute> _secUserModelAtrributes = new List<SecUserModelAtrribute>();
        public IReadOnlyCollection<SecUserModelAtrribute> SecUserModelAtrributes => _secUserModelAtrributes;

        private List<SecUserModule> _secUserModules = new List<SecUserModule>();
        public IReadOnlyCollection<SecUserModule> SecUserModules => _secUserModules;

        private List<SecUserProperty> _secUserProperties = new List<SecUserProperty>();
        public IReadOnlyCollection<SecUserProperty> SecUserProperties => _secUserProperties;

        private List<SecUserViewAction> _secUserViewActions = new List<SecUserViewAction>();
        public IReadOnlyCollection<SecUserViewAction> SecUserViewActions => _secUserViewActions;

        private List<StoreKeeper> _storeKeepers = new List<StoreKeeper>();
        public IReadOnlyCollection<StoreKeeper> StoreKeepers => _storeKeepers;

        private List<Store> _stores = new List<Store>();
        public IReadOnlyCollection<Store> Stores => _stores;

        private List<UserSessionInfo> _userSessionInfos = new List<UserSessionInfo>();
        public IReadOnlyCollection<UserSessionInfo> UserSessionInfos => _userSessionInfos;

        private List<VendorOrder> _vendorOrderAssignedToUserFkNavigations = new List<VendorOrder>();
        public IReadOnlyCollection<VendorOrder> VendorOrderAssignedToUserFkNavigations => _vendorOrderAssignedToUserFkNavigations;

        private List<VendorOrder> _vendorOrderCreatedByNavigations = new List<VendorOrder>();
        public IReadOnlyCollection<VendorOrder> VendorOrderCreatedByNavigations => _vendorOrderCreatedByNavigations;

        private List<VendorOrder> _vendorOrderLastUpdatedByNavigations = new List<VendorOrder>();
        public IReadOnlyCollection<VendorOrder> VendorOrderLastUpdatedByNavigations => _vendorOrderLastUpdatedByNavigations;

        private List<VendorOrder> _vendorOrderOrderByUserFkNavigations = new List<VendorOrder>();
        public IReadOnlyCollection<VendorOrder> VendorOrderOrderByUserFkNavigations => _vendorOrderOrderByUserFkNavigations;

        private List<Visit> _visits = new List<Visit>();
        public IReadOnlyCollection<Visit> Visits => _visits;

        private List<SecRole> _roles = new List<SecRole>();
        public IReadOnlyCollection<SecRole> Roles => _roles;

        public User()
        {
        }

        public User(DateTime? updatedOn, string? code, string? name, string? userId, string? password, string? email, string? phone, string? address, int? contact, bool? active, int? ouid, string? nameAr, int? branchId, DateTime? lastLogin, bool? forcePasswordChange, int? employeeId, int? maxDiscount, DateTime? passwordCreationDate, string? fullName, byte[]? profilePicture, int? adUserId, bool? isPda, int? singleSession, byte[] timestamp, bool isActive) : this()
        {
            UpdatedOn = updatedOn;
            Code = code;
            Name = name;
            UserId = userId;
            Password = password;
            Email = email;
            Phone = phone;
            Address = address;
            Contact = contact;
            Active = active;
            Ouid = ouid;
            NameAr = nameAr;
            BranchId = branchId;
            LastLogin = lastLogin;
            ForcePasswordChange = forcePasswordChange;
            EmployeeId = employeeId;
            MaxDiscount = maxDiscount;
            PasswordCreationDate = passwordCreationDate;
            FullName = fullName;
            ProfilePicture = profilePicture;
            AdUserId = adUserId;
            IsPda = isPda;
            SingleSession = singleSession;
            Timestamp = timestamp;
            IsActive = isActive;
        }

        public static User Create(DateTime? updatedOn, string? code, string? name, string? userId, string? password, string? email, string? phone, string? address, int? contact, bool? active, int? ouid, string? nameAr, int? branchId, DateTime? lastLogin, bool? forcePasswordChange, int? employeeId, int? maxDiscount, DateTime? passwordCreationDate, string? fullName, byte[]? profilePicture, int? adUserId, bool? isPda, int? singleSession, byte[] timestamp, bool isActive)
        {

            return new User(updatedOn, code, name, userId, password, email, phone, address, contact, active, ouid, nameAr, branchId, lastLogin, forcePasswordChange, employeeId, maxDiscount, passwordCreationDate, fullName, profilePicture, adUserId, isPda, singleSession, timestamp, isActive);
        }

        public void Update(DateTime? updatedOn, string? code, string? name, string? userId, string? password, string? email, string? phone, string? address, int? contact, bool? active, int? ouid, string? nameAr, int? branchId, DateTime? lastLogin, bool? forcePasswordChange, int? employeeId, int? maxDiscount, DateTime? passwordCreationDate, string? fullName, byte[]? profilePicture, int? adUserId, bool? isPda, int? singleSession, byte[] timestamp, bool isActive)
        {
            UpdatedOn = updatedOn;
            Code = code;
            Name = name;
            UserId = userId;
            Password = password;
            Email = email;
            Phone = phone;
            Address = address;
            Contact = contact;
            Active = active;
            Ouid = ouid;
            NameAr = nameAr;
            BranchId = branchId;
            LastLogin = lastLogin;
            ForcePasswordChange = forcePasswordChange;
            EmployeeId = employeeId;
            MaxDiscount = maxDiscount;
            PasswordCreationDate = passwordCreationDate;
            FullName = fullName;
            ProfilePicture = profilePicture;
            AdUserId = adUserId;
            IsPda = isPda;
            SingleSession = singleSession;
            Timestamp = timestamp;
            IsActive = isActive;
        }
    }
}
