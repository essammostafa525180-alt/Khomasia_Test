namespace Application.CQRS.ModuleSetting;

public record ModuleSettingDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? SettingName,
    string? SettingValue,
    string? Measure,
    string? MeasureAr,
    int? DataType
);