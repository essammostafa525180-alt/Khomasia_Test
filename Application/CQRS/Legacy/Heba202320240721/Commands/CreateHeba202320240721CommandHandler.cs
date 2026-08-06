using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.Heba202320240721;

public class CreateHeba202320240721Command : ICommand<Result<int>>
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
        public double? Quantity { get; set; }
        public double? TotalCost { get; set; }
        public long? InventoryItemFk { get; set; }
}
internal class CreateHeba202320240721CommandHandler : ICommandHandler<CreateHeba202320240721Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public CreateHeba202320240721CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(CreateHeba202320240721Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO [Heba_2023_20240721$] ([ItemNumber], [ItemName], [Store1], [Store4], [Store5], [Store6], [Store7], [Store8], [AverageCost], [Quantity], [TotalCost], [InventoryItemFk]) VALUES ({request.ItemNumber}, {request.ItemName}, {request.Store1}, {request.Store4}, {request.Store5}, {request.Store6}, {request.Store7}, {request.Store8}, {request.AverageCost}, {request.Quantity}, {request.TotalCost}, {request.InventoryItemFk})");

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotInserted);
    }
}
