namespace Application.CQRS.SecModelAttribute;

public record SecModelAttributeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int ModelAttributeId,
    int? ModelId,
    string? AttributeName,
    string? AttributeDisplayName,
    string? AttributeDisplayNameAr
);