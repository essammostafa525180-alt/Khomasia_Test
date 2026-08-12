using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.CairoAvgcost20240729;

public class DeleteCairoAvgcost20240729Command : ICommand<Result<int>>
{
}
internal class DeleteCairoAvgcost20240729CommandHandler : ICommandHandler<DeleteCairoAvgcost20240729Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteCairoAvgcost20240729CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteCairoAvgcost20240729Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.CairoAvgcost20240729s.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
