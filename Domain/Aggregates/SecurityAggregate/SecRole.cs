using Domain.Aggregates.UserAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.SecurityAggregate
{
    public class SecRole : AggregateRootEntityBase<int>
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public bool? IsAdmin { get; set; }
        public string? RoleNameAr { get; set; }
        public bool? SingleSession { get; set; }

        private List<SecRoleModelAttribute> _secRoleModelAttributes = new List<SecRoleModelAttribute>();
        public IReadOnlyCollection<SecRoleModelAttribute> SecRoleModelAttributes => _secRoleModelAttributes;

        private List<SecRoleModule> _secRoleModules = new List<SecRoleModule>();
        public IReadOnlyCollection<SecRoleModule> SecRoleModules => _secRoleModules;

        private List<SecRoleProperty> _secRoleProperties = new List<SecRoleProperty>();
        public IReadOnlyCollection<SecRoleProperty> SecRoleProperties => _secRoleProperties;

        private List<SecRoleViewAction> _secRoleViewActions = new List<SecRoleViewAction>();
        public IReadOnlyCollection<SecRoleViewAction> SecRoleViewActions => _secRoleViewActions;

        private List<User> _users = new List<User>();
        public IReadOnlyCollection<User> Users => _users;

        public SecRole()
        {
        }

        public SecRole(int roleId, string? roleName, bool? isAdmin, string? roleNameAr, bool? singleSession, bool isActive) : this()
        {
            RoleId = roleId;
            RoleName = roleName;
            IsAdmin = isAdmin;
            RoleNameAr = roleNameAr;
            SingleSession = singleSession;
            IsActive = isActive;
        }

        public static SecRole Create(int roleId, string? roleName, bool? isAdmin, string? roleNameAr, bool? singleSession, bool isActive)
        {

            return new SecRole(roleId, roleName, isAdmin, roleNameAr, singleSession, isActive);
        }

        public void Update(int roleId, string? roleName, bool? isAdmin, string? roleNameAr, bool? singleSession, bool isActive)
        {
            RoleId = roleId;
            RoleName = roleName;
            IsAdmin = isAdmin;
            RoleNameAr = roleNameAr;
            SingleSession = singleSession;
            IsActive = isActive;
        }
    }
}
