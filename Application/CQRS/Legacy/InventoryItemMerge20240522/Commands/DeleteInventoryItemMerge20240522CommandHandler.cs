using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.InventoryItemMerge20240522;

public class DeleteInventoryItemMerge20240522Command : ICommand<Result<int>>
{
}
internal class DeleteInventoryItemMerge20240522CommandHandler : ICommandHandler<DeleteInventoryItemMerge20240522Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteInventoryItemMerge20240522CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteInventoryItemMerge20240522Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.InventoryItemMerge20240522s.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
