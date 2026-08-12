using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.PoChangeVehicle20240331;

public class CreatePoChangeVehicle20240331Command : ICommand<Result<int>>
{
        public string? RequestNo { get; set; }
        public string? CurrentVehicleCode { get; set; }
        public long? Mrid { get; set; }
        public long? OldVehicleId { get; set; }
        public long? VehicleId { get; set; }
}
internal class CreatePoChangeVehicle20240331CommandHandler : ICommandHandler<CreatePoChangeVehicle20240331Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public CreatePoChangeVehicle20240331CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(CreatePoChangeVehicle20240331Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO [$po_ChangeVehicle_2024-03-31] ([RequestNo], [CurrentVehicleCode], [Mrid], [OldVehicleId], [VehicleId]) VALUES ({request.RequestNo}, {request.CurrentVehicleCode}, {request.Mrid}, {request.OldVehicleId}, {request.VehicleId})");

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotInserted);
    }
}
