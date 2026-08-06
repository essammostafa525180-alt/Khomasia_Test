using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.ProcDatum;

public class DeleteProcDatumCommand : ICommand<Result<int>>
{
}
internal class DeleteProcDatumCommandHandler : ICommandHandler<DeleteProcDatumCommand, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteProcDatumCommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteProcDatumCommand request, CancellationToken cancellationToken)
    {
        var affected = await _db.ProcData.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
