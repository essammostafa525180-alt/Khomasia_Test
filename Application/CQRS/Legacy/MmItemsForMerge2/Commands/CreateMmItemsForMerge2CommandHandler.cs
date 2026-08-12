using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.MmItemsForMerge2;

public class CreateMmItemsForMerge2Command : ICommand<Result<int>>
{
        public double? Id { get; set; }
        public string? ItemNumber { get; set; }
        public string? MainItem { get; set; }
}
internal class CreateMmItemsForMerge2CommandHandler : ICommandHandler<CreateMmItemsForMerge2Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public CreateMmItemsForMerge2CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(CreateMmItemsForMerge2Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO [MM Items For Merge_2$] ([Id], [ItemNumber], [MainItem]) VALUES ({request.Id}, {request.ItemNumber}, {request.MainItem})");

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotInserted);
    }
}
