using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.CairoAvgcost20240729;

public class CreateCairoAvgcost20240729Command : ICommand<Result<int>>
{
        public double? Id { get; set; }
        public string? ItemNumber { get; set; }
        public string? ItemName { get; set; }
        public string? Store { get; set; }
        public double? OpeningBalance { get; set; }
        public double? Avgcost { get; set; }
        public double? TotalCost { get; set; }
}
internal class CreateCairoAvgcost20240729CommandHandler : ICommandHandler<CreateCairoAvgcost20240729Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public CreateCairoAvgcost20240729CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(CreateCairoAvgcost20240729Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO [CairoAVGCost20240729$] ([Id], [ItemNumber], [ItemName], [Store], [OpeningBalance], [Avgcost], [TotalCost]) VALUES ({request.Id}, {request.ItemNumber}, {request.ItemName}, {request.Store}, {request.OpeningBalance}, {request.Avgcost}, {request.TotalCost})");

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotInserted);
    }
}
