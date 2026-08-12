using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.InventoryItemLocation20230505;

public class CreateInventoryItemLocation20230505Command : ICommand<Result<int>>
{
        public long Id { get; set; }
        public long? InventoryItemFk { get; set; }
        public long? StoreFk { get; set; }
        public decimal? Quantity { get; set; }
        public long? ItemQuantityTypeFk { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public long? LastUpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public byte[] RowVersion { get; set; }
}
internal class CreateInventoryItemLocation20230505CommandHandler : ICommandHandler<CreateInventoryItemLocation20230505Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public CreateInventoryItemLocation20230505CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemLocation20230505Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO [InventoryItemLocation_20230505] ([Id], [InventoryItemFk], [StoreFk], [Quantity], [ItemQuantityTypeFk], [CreatedOn], [LastUpdatedOn], [CreatedBy], [LastUpdatedBy], [IsActive], [RowVersion]) VALUES ({request.Id}, {request.InventoryItemFk}, {request.StoreFk}, {request.Quantity}, {request.ItemQuantityTypeFk}, {request.CreatedOn}, {request.LastUpdatedOn}, {request.CreatedBy}, {request.LastUpdatedBy}, {request.IsActive}, {request.RowVersion})");

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotInserted);
    }
}
