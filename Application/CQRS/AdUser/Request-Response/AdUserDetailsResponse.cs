namespace Application.CQRS.AdUser;

public record AdUserDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? AdAccount,
    string? Mail
);