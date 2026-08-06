using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.TempBatch;

public class DeleteTempBatchCommand : ICommand<Result<int>>
{
}
internal class DeleteTempBatchCommandHandler : ICommandHandler<DeleteTempBatchCommand, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteTempBatchCommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteTempBatchCommand request, CancellationToken cancellationToken)
    {
        var affected = await _db.TempBatches.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
