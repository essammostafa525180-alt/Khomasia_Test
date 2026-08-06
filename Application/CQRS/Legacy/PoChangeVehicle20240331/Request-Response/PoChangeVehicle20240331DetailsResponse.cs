namespace Application.CQRS.Legacy.PoChangeVehicle20240331;

public record PoChangeVehicle20240331DetailsResponse
(
         string? RequestNo,
         string? CurrentVehicleCode,
         long? Mrid,
         long? OldVehicleId,
         long? VehicleId
);
