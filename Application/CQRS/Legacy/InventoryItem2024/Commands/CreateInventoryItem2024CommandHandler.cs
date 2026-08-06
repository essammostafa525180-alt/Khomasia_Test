using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.InventoryItem2024;

public class CreateInventoryItem2024Command : ICommand<Result<int>>
{
        public string? Store { get; set; }
        public string? ItemCardEn { get; set; }
        public string? ItemCardAr { get; set; }
        public string? MaterialGroup { get; set; }
        public string? MaterialCategory { get; set; }
        public string? MaterialSubCategory { get; set; }
        public double? TotalQuantity { get; set; }
        public string? UnitOfMeasure { get; set; }
        public string? MaterialGroup1 { get; set; }
        public long? MaterialGroupFk { get; set; }
        public long? MaterialCategoryFk { get; set; }
        public long? MaterialSubCategoryFk { get; set; }
        public long? UnitOfMeasureFk { get; set; }
}
internal class CreateInventoryItem2024CommandHandler : ICommandHandler<CreateInventoryItem2024Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public CreateInventoryItem2024CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(CreateInventoryItem2024Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO [$InventoryItem_2024] ([Store], [ItemCardEn], [ItemCardAr], [MaterialGroup], [MaterialCategory], [MaterialSubCategory], [TotalQuantity], [UnitOfMeasure], [MaterialGroup1], [MaterialGroupFk], [MaterialCategoryFk], [MaterialSubCategoryFk], [UnitOfMeasureFk]) VALUES ({request.Store}, {request.ItemCardEn}, {request.ItemCardAr}, {request.MaterialGroup}, {request.MaterialCategory}, {request.MaterialSubCategory}, {request.TotalQuantity}, {request.UnitOfMeasure}, {request.MaterialGroup1}, {request.MaterialGroupFk}, {request.MaterialCategoryFk}, {request.MaterialSubCategoryFk}, {request.UnitOfMeasureFk})");

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotInserted);
    }
}
