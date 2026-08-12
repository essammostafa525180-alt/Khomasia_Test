using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.NotFoundItem;

public class CreateNotFoundItemCommand : ICommand<Result<int>>
{
        public string? ItemCode { get; set; }
        public string? Store { get; set; }
        public double? Balance { get; set; }
        public DateTime? Date { get; set; }
        public string? Id { get; set; }
        public string? Code { get; set; }
        public string? Duplicated { get; set; }
}
internal class CreateNotFoundItemCommandHandler : ICommandHandler<CreateNotFoundItemCommand, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public CreateNotFoundItemCommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(CreateNotFoundItemCommand request, CancellationToken cancellationToken)
    {
        var affected = await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO [Not found items$] ([ItemCode], [Store], [Balance], [Date], [Id], [Code], [Duplicated]) VALUES ({request.ItemCode}, {request.Store}, {request.Balance}, {request.Date}, {request.Id}, {request.Code}, {request.Duplicated})");

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotInserted);
    }
}
