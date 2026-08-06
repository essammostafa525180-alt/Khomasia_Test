namespace Application.CQRS.HadithSharhMissing;

public record HadithSharhMissingDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int HadithNumber,
    int? BabId,
    int? BookSharhId,
    string? SharhWithSign,
    string? SharhWithNoSign,
    int HadithId
);