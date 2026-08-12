using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.Heba202320240721merge;

public class CreateHeba202320240721mergeCommand : ICommand<Result<int>>
{
        public long Id { get; set; }
        public string? DeletedItemNumber { get; set; }
        public string? ItemNumber { get; set; }
        public long? InventoryItemFk { get; set; }
        public double? NewAverageCost { get; set; }
        public double? DeletedAverageCost { get; set; }
}
internal class CreateHeba202320240721mergeCommandHandler : ICommandHandler<CreateHeba202320240721mergeCommand, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public CreateHeba202320240721mergeCommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(CreateHeba202320240721mergeCommand request, CancellationToken cancellationToken)
    {
        var affected = await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO [Heba_2023_2024-07-21Merge$] ([Id], [DeletedItemNumber], [ItemNumber], [InventoryItemFk], [NewAverageCost], [DeletedAverageCost]) VALUES ({request.Id}, {request.DeletedItemNumber}, {request.ItemNumber}, {request.InventoryItemFk}, {request.NewAverageCost}, {request.DeletedAverageCost})");

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotInserted);
    }
}
