using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.HebaAvgcost20240729;

public class DeleteHebaAvgcost20240729Command : ICommand<Result<int>>
{
}
internal class DeleteHebaAvgcost20240729CommandHandler : ICommandHandler<DeleteHebaAvgcost20240729Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteHebaAvgcost20240729CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteHebaAvgcost20240729Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.HebaAvgcost20240729s.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
