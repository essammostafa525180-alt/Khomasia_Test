using Domain.Aggregates.SecurityAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class SecModelAttribute : AuditableEntityBase<int>
    {
        public int ModelAttributeId { get; private set; }
        public int? ModelId { get; private set; }
        public string? AttributeName { get; private set; }
        public string? AttributeDisplayName { get; private set; }
        public string? AttributeDisplayNameAr { get; private set; }
        public SecModel? Model { get; private set; }

        private List<SecRoleModelAttribute> _secRoleModelAttributes = new List<SecRoleModelAttribute>();
        public IReadOnlyCollection<SecRoleModelAttribute> SecRoleModelAttributes => _secRoleModelAttributes;

        private List<SecUserModelAtrribute> _secUserModelAtrributes = new List<SecUserModelAtrribute>();
        public IReadOnlyCollection<SecUserModelAtrribute> SecUserModelAtrributes => _secUserModelAtrributes;

        private SecModelAttribute()
        {
        }

        public SecModelAttribute(int modelAttributeId, int? modelId, string? attributeName, string? attributeDisplayName, string? attributeDisplayNameAr, bool isActive) : this()
        {
            ModelAttributeId = modelAttributeId;
            ModelId = modelId;
            AttributeName = attributeName;
            AttributeDisplayName = attributeDisplayName;
            AttributeDisplayNameAr = attributeDisplayNameAr;
            IsActive = isActive;
        }

        public static SecModelAttribute Create(int modelAttributeId, int? modelId, string? attributeName, string? attributeDisplayName, string? attributeDisplayNameAr, bool isActive)
        {

            return new SecModelAttribute(modelAttributeId, modelId, attributeName, attributeDisplayName, attributeDisplayNameAr, isActive);
        }

        public void Update(int modelAttributeId, int? modelId, string? attributeName, string? attributeDisplayName, string? attributeDisplayNameAr, bool isActive)
        {
            ModelAttributeId = modelAttributeId;
            ModelId = modelId;
            AttributeName = attributeName;
            AttributeDisplayName = attributeDisplayName;
            AttributeDisplayNameAr = attributeDisplayNameAr;
            IsActive = isActive;
        }
    }
}
