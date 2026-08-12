namespace Application.CQRS.Expense;

public record ExpenseDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr,
    int? CompanyFk
);