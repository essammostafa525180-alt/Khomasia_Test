using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.InventoryItemLocation20240723;

public class DeleteInventoryItemLocation20240723Command : ICommand<Result<int>>
{
}
internal class DeleteInventoryItemLocation20240723CommandHandler : ICommandHandler<DeleteInventoryItemLocation20240723Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteInventoryItemLocation20240723CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteInventoryItemLocation20240723Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.InventoryItemLocation20240723s.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
