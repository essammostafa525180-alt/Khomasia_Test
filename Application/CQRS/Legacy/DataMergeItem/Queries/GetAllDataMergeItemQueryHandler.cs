using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.DataMergeItem;

public class GetAllDataMergeItemQuery
: IQuery<Result<PagingSortingFiltering<DataMergeItemDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllDataMergeItemQueryHandler :
    IQueryHandler<GetAllDataMergeItemQuery,
        Result<PagingSortingFiltering<DataMergeItemDetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllDataMergeItemQueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<DataMergeItemDetailsResponse>>> Handle(
        GetAllDataMergeItemQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _db.DataMergeItems
                            .AsNoTracking()
                            .ProjectToType<DataMergeItemDetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<DataMergeItemDetailsResponse>>.Success(result);
    }
}
