using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.Cairo202320240721merge;

public class CreateCairo202320240721mergeCommand : ICommand<Result<int>>
{
        public long Id { get; set; }
        public string? DeletedItemNumber { get; set; }
        public string? ItemNumber { get; set; }
        public long? InventoryItemFk { get; set; }
        public double? DeletedAverageCost { get; set; }
        public double? NewAverageCost { get; set; }
}
internal class CreateCairo202320240721mergeCommandHandler : ICommandHandler<CreateCairo202320240721mergeCommand, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public CreateCairo202320240721mergeCommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(CreateCairo202320240721mergeCommand request, CancellationToken cancellationToken)
    {
        var affected = await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO [Cairo_2023_2024-07-21Merge$] ([Id], [DeletedItemNumber], [ItemNumber], [InventoryItemFk], [DeletedAverageCost], [NewAverageCost]) VALUES ({request.Id}, {request.DeletedItemNumber}, {request.ItemNumber}, {request.InventoryItemFk}, {request.DeletedAverageCost}, {request.NewAverageCost})");

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotInserted);
    }
}
