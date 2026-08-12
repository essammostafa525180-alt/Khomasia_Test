namespace Application.CQRS.RwDeliveredSerial;

public record RwDeliveredSerialDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? RwDeliveredBatchFk,
    int? SerialFk,
    bool? Axsynced
);