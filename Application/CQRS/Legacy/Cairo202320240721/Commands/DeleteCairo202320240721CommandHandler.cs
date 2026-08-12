using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.Cairo202320240721;

public class DeleteCairo202320240721Command : ICommand<Result<int>>
{
}
internal class DeleteCairo202320240721CommandHandler : ICommandHandler<DeleteCairo202320240721Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteCairo202320240721CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteCairo202320240721Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.Cairo202320240721s.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
