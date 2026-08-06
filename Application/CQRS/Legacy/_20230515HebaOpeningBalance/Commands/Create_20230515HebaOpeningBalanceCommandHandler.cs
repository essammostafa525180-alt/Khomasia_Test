using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy._20230515HebaOpeningBalance;

public class Create_20230515HebaOpeningBalanceCommand : ICommand<Result<int>>
{
        public string? ItemNumber { get; set; }
        public string? ItemName { get; set; }
        public double? Store1 { get; set; }
        public double? Store4 { get; set; }
        public double? Store5 { get; set; }
        public double? Store6 { get; set; }
        public double? Store7 { get; set; }
        public double? Store8 { get; set; }
        public double? AverageCost { get; set; }
}
internal class Create_20230515HebaOpeningBalanceCommandHandler : ICommandHandler<Create_20230515HebaOpeningBalanceCommand, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public Create_20230515HebaOpeningBalanceCommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(Create_20230515HebaOpeningBalanceCommand request, CancellationToken cancellationToken)
    {
        var affected = await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO [$20230515_Heba_OpeningBalance] ([ItemNumber], [ItemName], [Store1], [Store4], [Store5], [Store6], [Store7], [Store8], [AverageCost]) VALUES ({request.ItemNumber}, {request.ItemName}, {request.Store1}, {request.Store4}, {request.Store5}, {request.Store6}, {request.Store7}, {request.Store8}, {request.AverageCost})");

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotInserted);
    }
}
