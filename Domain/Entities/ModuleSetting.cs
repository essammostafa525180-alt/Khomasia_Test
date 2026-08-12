using Domain.Primitives;

namespace Domain.Entities
{
    public class ModuleSetting : AuditableEntityBase<int>
    {
        public string? SettingName { get; private set; }
        public string? SettingValue { get; private set; }
        public string? Measure { get; private set; }
        public string? MeasureAr { get; private set; }
        public int? DataType { get; private set; }

        private ModuleSetting()
        {
        }

        public ModuleSetting(string? settingName, string? settingValue, string? measure, string? measureAr, int? dataType, bool isActive) : this()
        {
            SettingName = settingName;
            SettingValue = settingValue;
            Measure = measure;
            MeasureAr = measureAr;
            DataType = dataType;
            IsActive = isActive;
        }

        public static ModuleSetting Create(string? settingName, string? settingValue, string? measure, string? measureAr, int? dataType, bool isActive)
        {

            return new ModuleSetting(settingName, settingValue, measure, measureAr, dataType, isActive);
        }

        public void Update(string? settingName, string? settingValue, string? measure, string? measureAr, int? dataType, bool isActive)
        {
            SettingName = settingName;
            SettingValue = settingValue;
            Measure = measure;
            MeasureAr = measureAr;
            DataType = dataType;
            IsActive = isActive;
        }
    }
}
