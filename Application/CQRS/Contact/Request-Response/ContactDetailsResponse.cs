namespace Application.CQRS.Contact;

public record ContactDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? ContactValue,
    int? ContactTypeId,
    DateTime? UpdatedOn
);