using System.Globalization;
using System.Reflection;

namespace Domain.ValueObjects;

public record DescriptionLocalized(string NameAr, string NameEn) // علشان اللغة 
{
    public string Name => GetLocalizedPropertyValue(nameof(Name));
    public virtual string GetLocalizedPropertyValue(string propertyName)
    {
        var currentCulture = CultureInfo.CurrentCulture;
        var twoLetterCulture = currentCulture.TwoLetterISOLanguageName;

        var culturePropertyName = propertyName + twoLetterCulture;

        return (string)GetType().GetProperty(culturePropertyName, BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance)?.GetValue(this, null);
    }
}
