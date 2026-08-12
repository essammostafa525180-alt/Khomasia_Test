namespace Application.CQRS.UserSessionInfoDetail;

public record UserSessionInfoDetailDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? UserSessionInfoId,
    int? InfoKey,
    string? InfoValue,
    string? InfoDescription
);