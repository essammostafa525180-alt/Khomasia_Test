using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.PoChangeVehicle20240331;

public class DeletePoChangeVehicle20240331Command : ICommand<Result<int>>
{
}
internal class DeletePoChangeVehicle20240331CommandHandler : ICommandHandler<DeletePoChangeVehicle20240331Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeletePoChangeVehicle20240331CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeletePoChangeVehicle20240331Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.PoChangeVehicle20240331s.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
