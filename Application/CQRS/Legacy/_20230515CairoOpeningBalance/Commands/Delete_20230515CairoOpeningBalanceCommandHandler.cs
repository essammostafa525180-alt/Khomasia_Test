using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy._20230515CairoOpeningBalance;

public class Delete_20230515CairoOpeningBalanceCommand : ICommand<Result<int>>
{
}
internal class Delete_20230515CairoOpeningBalanceCommandHandler : ICommandHandler<Delete_20230515CairoOpeningBalanceCommand, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public Delete_20230515CairoOpeningBalanceCommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(Delete_20230515CairoOpeningBalanceCommand request, CancellationToken cancellationToken)
    {
        var affected = await _db._20230515CairoOpeningBalances.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
