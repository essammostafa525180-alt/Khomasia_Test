using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.DataMergeItem;

public class DeleteDataMergeItemCommand : ICommand<Result<int>>
{
}
internal class DeleteDataMergeItemCommandHandler : ICommandHandler<DeleteDataMergeItemCommand, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteDataMergeItemCommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteDataMergeItemCommand request, CancellationToken cancellationToken)
    {
        var affected = await _db.DataMergeItems.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
