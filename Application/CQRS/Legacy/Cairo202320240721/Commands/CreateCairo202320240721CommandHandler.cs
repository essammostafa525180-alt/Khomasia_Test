using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.Cairo202320240721;

public class CreateCairo202320240721Command : ICommand<Result<int>>
{
        public string? ItemNumber { get; set; }
        public string? ItemName { get; set; }
        public double? Store2 { get; set; }
        public double? Store3 { get; set; }
        public double? Store9 { get; set; }
        public double? AverageCost { get; set; }
        public double? Quantity { get; set; }
        public double? TotalCost { get; set; }
        public long? InventoryItemFk { get; set; }
}
internal class CreateCairo202320240721CommandHandler : ICommandHandler<CreateCairo202320240721Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public CreateCairo202320240721CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(CreateCairo202320240721Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO [Cairo_2023_20240721$] ([ItemNumber], [ItemName], [Store2], [Store3], [Store9], [AverageCost], [Quantity], [TotalCost], [InventoryItemFk]) VALUES ({request.ItemNumber}, {request.ItemName}, {request.Store2}, {request.Store3}, {request.Store9}, {request.AverageCost}, {request.Quantity}, {request.TotalCost}, {request.InventoryItemFk})");

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotInserted);
    }
}
