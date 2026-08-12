using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.Cairo2024;

public class CreateCairo2024Command : ICommand<Result<int>>
{
        public string? Store { get; set; }
        public string? ItemName { get; set; }
        public double? Quantity { get; set; }
        public string? MaterialGroup { get; set; }
        public string? MaterialCategory { get; set; }
        public string? MaterialSubCategory { get; set; }
        public string? UnitOfMeasure { get; set; }
        public long? InventoryItemFk { get; set; }
        public long? StoreFk { get; set; }
}
internal class CreateCairo2024CommandHandler : ICommandHandler<CreateCairo2024Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public CreateCairo2024CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(CreateCairo2024Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO [Cairo_2024$] ([Store], [ItemName], [Quantity], [MaterialGroup], [MaterialCategory], [MaterialSubCategory], [UnitOfMeasure], [InventoryItemFk], [StoreFk]) VALUES ({request.Store}, {request.ItemName}, {request.Quantity}, {request.MaterialGroup}, {request.MaterialCategory}, {request.MaterialSubCategory}, {request.UnitOfMeasure}, {request.InventoryItemFk}, {request.StoreFk})");

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotInserted);
    }
}
