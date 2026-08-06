using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.Cairo202320240721merge;

public class DeleteCairo202320240721mergeCommand : ICommand<Result<int>>
{
}
internal class DeleteCairo202320240721mergeCommandHandler : ICommandHandler<DeleteCairo202320240721mergeCommand, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteCairo202320240721mergeCommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteCairo202320240721mergeCommand request, CancellationToken cancellationToken)
    {
        var affected = await _db.Cairo202320240721merges.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
