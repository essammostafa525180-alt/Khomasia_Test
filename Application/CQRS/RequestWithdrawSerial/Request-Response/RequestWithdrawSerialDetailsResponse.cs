namespace Application.CQRS.RequestWithdrawSerial;

public record RequestWithdrawSerialDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? RequestWithdrawFk,
    int? RequestWithdrawDetailFk,
    int? RwDeliveredQuantityFk,
    int? InventoryItemSerialFk
);