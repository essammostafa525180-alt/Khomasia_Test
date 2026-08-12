using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.InventoryItem2024;

public class DeleteInventoryItem2024Command : ICommand<Result<int>>
{
}
internal class DeleteInventoryItem2024CommandHandler : ICommandHandler<DeleteInventoryItem2024Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteInventoryItem2024CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteInventoryItem2024Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.InventoryItem2024s.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
