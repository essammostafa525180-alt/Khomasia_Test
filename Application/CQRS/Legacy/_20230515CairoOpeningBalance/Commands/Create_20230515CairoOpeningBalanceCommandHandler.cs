using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy._20230515CairoOpeningBalance;

public class Create_20230515CairoOpeningBalanceCommand : ICommand<Result<int>>
{
        public string? ItemNumber { get; set; }
        public string? ItemName { get; set; }
        public double? قطاعاكتوبر { get; set; }
        public double? قطاعالقطامية { get; set; }
        public double? HeadofficeCairo { get; set; }
        public double? AverageCostPerUnit { get; set; }
}
internal class Create_20230515CairoOpeningBalanceCommandHandler : ICommandHandler<Create_20230515CairoOpeningBalanceCommand, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public Create_20230515CairoOpeningBalanceCommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(Create_20230515CairoOpeningBalanceCommand request, CancellationToken cancellationToken)
    {
        var affected = await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO [$20230515_Cairo_OpeningBalance] ([ItemNumber], [ItemName], [قطاعاكتوبر], [قطاعالقطامية], [HeadofficeCairo], [AverageCostPerUnit]) VALUES ({request.ItemNumber}, {request.ItemName}, {request.قطاعاكتوبر}, {request.قطاعالقطامية}, {request.HeadofficeCairo}, {request.AverageCostPerUnit})");

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotInserted);
    }
}
