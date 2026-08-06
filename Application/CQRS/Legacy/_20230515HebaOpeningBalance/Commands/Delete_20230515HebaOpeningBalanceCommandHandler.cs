using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy._20230515HebaOpeningBalance;

public class Delete_20230515HebaOpeningBalanceCommand : ICommand<Result<int>>
{
}
internal class Delete_20230515HebaOpeningBalanceCommandHandler : ICommandHandler<Delete_20230515HebaOpeningBalanceCommand, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public Delete_20230515HebaOpeningBalanceCommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(Delete_20230515HebaOpeningBalanceCommand request, CancellationToken cancellationToken)
    {
        var affected = await _db._20230515HebaOpeningBalances.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
