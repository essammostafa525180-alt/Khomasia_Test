using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.Temp;

public class CreateTempCommand : ICommand<Result<int>>
{
        public string? Code { get; set; }
        public string? Name { get; set; }
}
internal class CreateTempCommandHandler : ICommandHandler<CreateTempCommand, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public CreateTempCommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(CreateTempCommand request, CancellationToken cancellationToken)
    {
        var affected = await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO [Temp] ([Code], [Name]) VALUES ({request.Code}, {request.Name})");

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotInserted);
    }
}
