using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.InventoryItemMerge20240610;

public class DeleteInventoryItemMerge20240610Command : ICommand<Result<int>>
{
}
internal class DeleteInventoryItemMerge20240610CommandHandler : ICommandHandler<DeleteInventoryItemMerge20240610Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteInventoryItemMerge20240610CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteInventoryItemMerge20240610Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.InventoryItemMerge20240610s.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
