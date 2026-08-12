using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.TempBatch;

public class GetAllTempBatchQuery
: IQuery<Result<PagingSortingFiltering<TempBatchDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllTempBatchQueryHandler :
    IQueryHandler<GetAllTempBatchQuery,
        Result<PagingSortingFiltering<TempBatchDetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllTempBatchQueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<TempBatchDetailsResponse>>> Handle(
        GetAllTempBatchQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _db.TempBatches
                            .AsNoTracking()
                            .ProjectToType<TempBatchDetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<TempBatchDetailsResponse>>.Success(result);
    }
}
