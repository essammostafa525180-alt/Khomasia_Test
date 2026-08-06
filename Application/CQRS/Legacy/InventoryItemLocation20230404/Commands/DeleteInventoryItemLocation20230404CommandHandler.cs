using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.InventoryItemLocation20230404;

public class DeleteInventoryItemLocation20230404Command : ICommand<Result<int>>
{
}
internal class DeleteInventoryItemLocation20230404CommandHandler : ICommandHandler<DeleteInventoryItemLocation20230404Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteInventoryItemLocation20230404CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteInventoryItemLocation20230404Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.InventoryItemLocation20230404s.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
