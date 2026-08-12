namespace Application.CQRS.SecUserModelAtrribute;

public record SecUserModelAtrributeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int UserId,
    int ModelAttributeId,
    int? Mode
);