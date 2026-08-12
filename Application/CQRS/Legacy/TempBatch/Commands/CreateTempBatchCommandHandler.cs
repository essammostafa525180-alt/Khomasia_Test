using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.TempBatch;

public class CreateTempBatchCommand : ICommand<Result<int>>
{
        public long? RowNumber { get; set; }
        public long BatchId { get; set; }
}
internal class CreateTempBatchCommandHandler : ICommandHandler<CreateTempBatchCommand, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public CreateTempBatchCommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(CreateTempBatchCommand request, CancellationToken cancellationToken)
    {
        var affected = await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO [TempBatch] ([RowNumber], [BatchId]) VALUES ({request.RowNumber}, {request.BatchId})");

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotInserted);
    }
}
