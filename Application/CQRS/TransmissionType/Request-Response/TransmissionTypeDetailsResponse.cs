namespace Application.CQRS.TransmissionType;

public record TransmissionTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr
);