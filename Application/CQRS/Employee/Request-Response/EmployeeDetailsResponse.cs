namespace Application.CQRS.Employee;

public record EmployeeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr,
    int? EmployeeJobFk
);