using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.Cairo2024;

public class DeleteCairo2024Command : ICommand<Result<int>>
{
}
internal class DeleteCairo2024CommandHandler : ICommandHandler<DeleteCairo2024Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteCairo2024CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteCairo2024Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.Cairo2024s.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
