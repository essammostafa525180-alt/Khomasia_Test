using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.StockCount20230331;

public class CreateStockCount20230331Command : ICommand<Result<int>>
{
        public string? ItemCode { get; set; }
        public string? Store { get; set; }
        public double? Balance { get; set; }
        public string? Date { get; set; }
        public int Id { get; set; }
        public string? ItemNumber { get; set; }
}
internal class CreateStockCount20230331CommandHandler : ICommandHandler<CreateStockCount20230331Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public CreateStockCount20230331CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(CreateStockCount20230331Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO [StockCount_2023-03-31$] ([ItemCode], [Store], [Balance], [Date], [Id], [ItemNumber]) VALUES ({request.ItemCode}, {request.Store}, {request.Balance}, {request.Date}, {request.Id}, {request.ItemNumber})");

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotInserted);
    }
}
