using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.Heba2024;

public class DeleteHeba2024Command : ICommand<Result<int>>
{
}
internal class DeleteHeba2024CommandHandler : ICommandHandler<DeleteHeba2024Command, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public DeleteHeba2024CommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(DeleteHeba2024Command request, CancellationToken cancellationToken)
    {
        var affected = await _db.Heba2024s.ExecuteDeleteAsync(cancellationToken);

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotDeleted);
    }
}
