using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.Heba202320240721merge;

public class DeleteHeba202320240721mergeCommand : ICommand<Result<int>>
{
}
internal class DeleteHeba202320240721mergeCommandHandler : ICommandHandler<DeleteHeba202320240721mergeCommand, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteHeba202320240721mergeCommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteHeba202320240721mergeCommand request, CancellationToken cancellationToken)
    {
        var affected = await _db.Heba202320240721merges.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
