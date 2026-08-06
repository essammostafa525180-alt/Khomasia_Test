namespace Application.CQRS.RwPickedSerial;

public record RwPickedSerialDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? RwPickedBatchFk,
    int? SerialFk,
    bool? Axsynced
);