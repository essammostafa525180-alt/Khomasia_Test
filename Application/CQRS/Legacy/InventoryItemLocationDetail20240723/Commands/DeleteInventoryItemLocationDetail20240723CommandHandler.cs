using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.InventoryItemLocationDetail20240723;

public class DeleteInventoryItemLocationDetail20240723Command : ICommand<Result<int>>
{
}
internal class DeleteInventoryItemLocationDetail20240723CommandHandler : ICommandHandler<DeleteInventoryItemLocationDetail20240723Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteInventoryItemLocationDetail20240723CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteInventoryItemLocationDetail20240723Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.InventoryItemLocationDetail20240723s.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
