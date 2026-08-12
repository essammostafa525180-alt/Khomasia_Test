using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.StockCount20230331;

public class DeleteStockCount20230331Command : ICommand<Result<int>>
{
}
internal class DeleteStockCount20230331CommandHandler : ICommandHandler<DeleteStockCount20230331Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteStockCount20230331CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteStockCount20230331Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.StockCount20230331s.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
