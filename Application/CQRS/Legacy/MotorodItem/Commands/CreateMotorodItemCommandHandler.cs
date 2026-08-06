using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.MotorodItem;

public class CreateMotorodItemCommand : ICommand<Result<int>>
{
        public string? MaterialGroup { get; set; }
        public string? ItemCategory { get; set; }
        public string? ItemName { get; set; }
        public string? Unit { get; set; }
        public double? Price { get; set; }
}
internal class CreateMotorodItemCommandHandler : ICommandHandler<CreateMotorodItemCommand, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public CreateMotorodItemCommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(CreateMotorodItemCommand request, CancellationToken cancellationToken)
    {
        var affected = await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO [$MotorodItems] ([MaterialGroup], [ItemCategory], [ItemName], [Unit], [Price]) VALUES ({request.MaterialGroup}, {request.ItemCategory}, {request.ItemName}, {request.Unit}, {request.Price})");

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotInserted);
    }
}
