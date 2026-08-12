using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.MmItemsForMerge2;

public class DeleteMmItemsForMerge2Command : ICommand<Result<int>>
{
}
internal class DeleteMmItemsForMerge2CommandHandler : ICommandHandler<DeleteMmItemsForMerge2Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteMmItemsForMerge2CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteMmItemsForMerge2Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.MmItemsForMerge2s.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
