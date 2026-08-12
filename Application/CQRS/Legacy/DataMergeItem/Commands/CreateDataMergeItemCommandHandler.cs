using Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.DataMergeItem;

public class CreateDataMergeItemCommand : ICommand<Result<int>>
{
        public long? OldItemFk { get; set; }
        public long? NewItemFk { get; set; }
        public DateTime? CreatedOn { get; set; }
}
internal class CreateDataMergeItemCommandHandler : ICommandHandler<CreateDataMergeItemCommand, Result<int>>
{
    private readonly IApplicationDbContext _db;

    public CreateDataMergeItemCommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<int>> Handle(CreateDataMergeItemCommand request, CancellationToken cancellationToken)
    {
        var affected = await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO [Data_Merge_Items] ([OldItemFk], [NewItemFk], [CreatedOn]) VALUES ({request.OldItemFk}, {request.NewItemFk}, {request.CreatedOn})");

        return affected > 0
            ? Result<int>.Success(affected)
            : Result<int>.Failure(Errors.LegacyNotInserted);
    }
}
