using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.Sheet1;

public class DeleteSheet1Command : ICommand<Result<int>>
{
}
internal class DeleteSheet1CommandHandler : ICommandHandler<DeleteSheet1Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteSheet1CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteSheet1Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.Sheet1s.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
