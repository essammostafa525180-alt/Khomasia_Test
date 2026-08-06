namespace Application.CQRS.Language;

public record LanguageDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? LanguageName,
    string? LanguageNameAr
);