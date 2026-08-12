namespace Application.CQRS.Pdaassignment;

public record PdaassignmentDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? PdadetailFk,
    int? UserFk
);