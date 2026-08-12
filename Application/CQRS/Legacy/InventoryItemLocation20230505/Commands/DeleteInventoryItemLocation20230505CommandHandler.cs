using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.InventoryItemLocation20230505;

public class DeleteInventoryItemLocation20230505Command : ICommand<Result<int>>
{
}
internal class DeleteInventoryItemLocation20230505CommandHandler : ICommandHandler<DeleteInventoryItemLocation20230505Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteInventoryItemLocation20230505CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteInventoryItemLocation20230505Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.InventoryItemLocation20230505s.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
