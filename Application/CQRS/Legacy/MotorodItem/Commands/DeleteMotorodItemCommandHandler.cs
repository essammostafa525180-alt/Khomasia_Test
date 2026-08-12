using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.MotorodItem;

public class DeleteMotorodItemCommand : ICommand<Result<int>>
{
}
internal class DeleteMotorodItemCommandHandler : ICommandHandler<DeleteMotorodItemCommand, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteMotorodItemCommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteMotorodItemCommand request, CancellationToken cancellationToken)
    {
        var affected = await _db.MotorodItems.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
