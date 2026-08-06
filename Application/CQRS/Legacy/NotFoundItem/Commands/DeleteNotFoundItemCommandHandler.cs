using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.NotFoundItem;

public class DeleteNotFoundItemCommand : ICommand<Result<int>>
{
}
internal class DeleteNotFoundItemCommandHandler : ICommandHandler<DeleteNotFoundItemCommand, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteNotFoundItemCommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteNotFoundItemCommand request, CancellationToken cancellationToken)
    {
        var affected = await _db.NotFoundItems.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
