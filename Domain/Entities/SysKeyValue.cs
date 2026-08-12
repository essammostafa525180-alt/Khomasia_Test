using Domain.Primitives;

namespace Domain.Entities
{
    public class SysKeyValue : AuditableEntityBase<int>
    {
        public string? SysKey { get; private set; }
        public string? SysValue { get; private set; }
        public string? Description { get; private set; }
        public string? DescriptionAr { get; private set; }

        private SysKeyValue()
        {
        }

        public SysKeyValue(string? sysKey, string? sysValue, string? description, string? descriptionAr, bool isActive) : this()
        {
            SysKey = sysKey;
            SysValue = sysValue;
            Description = description;
            DescriptionAr = descriptionAr;
            IsActive = isActive;
        }

        public static SysKeyValue Create(string? sysKey, string? sysValue, string? description, string? descriptionAr, bool isActive)
        {

            return new SysKeyValue(sysKey, sysValue, description, descriptionAr, isActive);
        }

        public void Update(string? sysKey, string? sysValue, string? description, string? descriptionAr, bool isActive)
        {
            SysKey = sysKey;
            SysValue = sysValue;
            Description = description;
            DescriptionAr = descriptionAr;
            IsActive = isActive;
        }
    }
}
