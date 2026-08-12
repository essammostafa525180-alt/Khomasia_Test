namespace Application.CQRS.StoreSequence;

public record StoreSequenceDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string TableName,
    int? SequenceValue
);