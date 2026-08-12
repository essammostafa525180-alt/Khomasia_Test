using Domain.Aggregates.SecurityAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class SecProperty : AuditableEntityBase<int>
    {
        public string? Type { get; private set; }
        public string? Name { get; private set; }
        public int? SecModuleId { get; private set; }
        public string? NameAr { get; private set; }
        public SecModule? SecModule { get; private set; }

        private List<SecRoleProperty> _secRoleProperties = new List<SecRoleProperty>();
        public IReadOnlyCollection<SecRoleProperty> SecRoleProperties => _secRoleProperties;

        private List<SecUserProperty> _secUserProperties = new List<SecUserProperty>();
        public IReadOnlyCollection<SecUserProperty> SecUserProperties => _secUserProperties;

        private SecProperty()
        {
        }

        public SecProperty(string? type, string? name, int? secModuleId, string? nameAr, bool isActive) : this()
        {
            Type = type;
            Name = name;
            SecModuleId = secModuleId;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static SecProperty Create(string? type, string? name, int? secModuleId, string? nameAr, bool isActive)
        {

            return new SecProperty(type, name, secModuleId, nameAr, isActive);
        }

        public void Update(string? type, string? name, int? secModuleId, string? nameAr, bool isActive)
        {
            Type = type;
            Name = name;
            SecModuleId = secModuleId;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
