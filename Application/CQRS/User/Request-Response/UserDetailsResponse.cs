namespace Application.CQRS.User;

public record UserDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    DateTime? UpdatedOn,
    string? Code,
    string? Name,
    string? UserId,
    string? Password,
    string? Email,
    string? Phone,
    string? Address,
    int? Contact,
    bool? Active,
    int? Ouid,
    string? NameAr,
    int? BranchId,
    DateTime? LastLogin,
    bool? ForcePasswordChange,
    int? EmployeeId,
    int? MaxDiscount,
    DateTime? PasswordCreationDate,
    string? FullName,
    byte[]? ProfilePicture,
    int? AdUserId,
    bool? IsPda,
    int? SingleSession,
    byte[] Timestamp
);