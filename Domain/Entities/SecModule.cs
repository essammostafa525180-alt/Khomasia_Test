using Domain.Aggregates.SecurityAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class SecModule : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public string? ModuleName { get; private set; }

        private List<SecModel> _secModels = new List<SecModel>();
        public IReadOnlyCollection<SecModel> SecModels => _secModels;

        private List<SecProperty> _secProperties = new List<SecProperty>();
        public IReadOnlyCollection<SecProperty> SecProperties => _secProperties;

        private List<SecRoleModule> _secRoleModules = new List<SecRoleModule>();
        public IReadOnlyCollection<SecRoleModule> SecRoleModules => _secRoleModules;

        private List<SecUserModule> _secUserModules = new List<SecUserModule>();
        public IReadOnlyCollection<SecUserModule> SecUserModules => _secUserModules;

        private List<SecView> _secViews = new List<SecView>();
        public IReadOnlyCollection<SecView> SecViews => _secViews;

        private SecModule()
        {
        }

        public SecModule(string? name, string? nameAr, string? moduleName, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            ModuleName = moduleName;
            IsActive = isActive;
        }

        public static SecModule Create(string? name, string? nameAr, string? moduleName, bool isActive)
        {

            return new SecModule(name, nameAr, moduleName, isActive);
        }

        public void Update(string? name, string? nameAr, string? moduleName, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            ModuleName = moduleName;
            IsActive = isActive;
        }
    }
}
