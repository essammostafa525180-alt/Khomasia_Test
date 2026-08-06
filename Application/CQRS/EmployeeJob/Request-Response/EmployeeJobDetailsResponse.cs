namespace Application.CQRS.EmployeeJob;

public record EmployeeJobDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr,
    int? EmployeeJobFk
);