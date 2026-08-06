using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.InventoryItemMerge20240610;

public class CreateInventoryItemMerge20240610Command : ICommand<Result<int>>
{
        public string? ItemNumber2024 { get; set; }
        public string? ItemNumber2023 { get; set; }
        public long? ItemNumber2024Id { get; set; }
        public long? ItemNumber2023Id { get; set; }
        public decimal? TotalQuantity2023 { get; set; }
        public decimal? OpeningQuantity2024 { get; set; }
        public decimal? TotalQuantity2024 { get; set; }
}
internal class CreateInventoryItemMerge20240610CommandHandler : ICommandHandler<CreateInventoryItemMerge20240610Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public CreateInventoryItemMerge20240610CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemMerge20240610Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO [$InventoryItemMerge_2024-06-10] ([ItemNumber2024], [ItemNumber2023], [ItemNumber2024Id], [ItemNumber2023Id], [TotalQuantity2023], [OpeningQuantity2024], [TotalQuantity2024]) VALUES ({request.ItemNumber2024}, {request.ItemNumber2023}, {request.ItemNumber2024Id}, {request.ItemNumber2023Id}, {request.TotalQuantity2023}, {request.OpeningQuantity2024}, {request.TotalQuantity2024})");

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotInserted);
    }
}
