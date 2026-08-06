using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.InventoryItemLocationDetail20240723;

public class CreateInventoryItemLocationDetail20240723Command : ICommand<Result<int>>
{
        public long Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public long? LastUpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public byte[] RowVersion { get; set; }
        public long? StoreFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public long? ItemQuantityTypeFk { get; set; }
        public long? TransactionTypeFk { get; set; }
        public string? Screen { get; set; }
        public long? EntityId { get; set; }
        public string? EntityCode { get; set; }
        public DateTime? EntityDate { get; set; }
        public long? EntityDetailId { get; set; }
        public long? InventoryItemLocationFk { get; set; }
        public decimal? QuantityBefore { get; set; }
        public decimal Quantity { get; set; }
        public decimal? QuantityAfter { get; set; }
        public decimal? EntityDetailCost { get; set; }
        public double? Avgcost { get; set; }
}
internal class CreateInventoryItemLocationDetail20240723CommandHandler : ICommandHandler<CreateInventoryItemLocationDetail20240723Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public CreateInventoryItemLocationDetail20240723CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemLocationDetail20240723Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO [$InventoryItemLocationDetail_20240723] ([Id], [CreatedOn], [LastUpdatedOn], [CreatedBy], [LastUpdatedBy], [IsActive], [RowVersion], [StoreFk], [InventoryItemFk], [ItemQuantityTypeFk], [TransactionTypeFk], [Screen], [EntityId], [EntityCode], [EntityDate], [EntityDetailId], [InventoryItemLocationFk], [QuantityBefore], [Quantity], [QuantityAfter], [EntityDetailCost], [Avgcost]) VALUES ({request.Id}, {request.CreatedOn}, {request.LastUpdatedOn}, {request.CreatedBy}, {request.LastUpdatedBy}, {request.IsActive}, {request.RowVersion}, {request.StoreFk}, {request.InventoryItemFk}, {request.ItemQuantityTypeFk}, {request.TransactionTypeFk}, {request.Screen}, {request.EntityId}, {request.EntityCode}, {request.EntityDate}, {request.EntityDetailId}, {request.InventoryItemLocationFk}, {request.QuantityBefore}, {request.Quantity}, {request.QuantityAfter}, {request.EntityDetailCost}, {request.Avgcost})");

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotInserted);
    }
}
