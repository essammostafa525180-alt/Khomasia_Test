namespace Application.CQRS.Isle;

public record IsleDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int StorageUnitFk,
    string? Code,
    string? Name,
    int Sequence
);
