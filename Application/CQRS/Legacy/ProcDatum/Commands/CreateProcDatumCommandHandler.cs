using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.ProcDatum;

public class CreateProcDatumCommand : ICommand<Result<int>>
{
        public long Id { get; set; }
        public string? Description { get; set; }
        public string? Query { get; set; }
        public bool IsRun { get; set; }
}
internal class CreateProcDatumCommandHandler : ICommandHandler<CreateProcDatumCommand, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public CreateProcDatumCommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(CreateProcDatumCommand request, CancellationToken cancellationToken)
    {
        var affected = await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO [ProcData] ([Id], [Description], [Query], [IsRun]) VALUES ({request.Id}, {request.Description}, {request.Query}, {request.IsRun})");

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotInserted);
    }
}
