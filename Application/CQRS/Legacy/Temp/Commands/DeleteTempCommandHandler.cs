using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.Temp;

public class DeleteTempCommand : ICommand<Result<int>>
{
}
internal class DeleteTempCommandHandler : ICommandHandler<DeleteTempCommand, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteTempCommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteTempCommand request, CancellationToken cancellationToken)
    {
        var affected = await _db.Temps.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
