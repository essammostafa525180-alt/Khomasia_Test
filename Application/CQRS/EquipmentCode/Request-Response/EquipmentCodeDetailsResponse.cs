namespace Application.CQRS.EquipmentCode;

public record EquipmentCodeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr
);