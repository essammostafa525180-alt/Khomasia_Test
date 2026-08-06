using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.Cairo202320240721merge;

public class GetAllCairo202320240721mergeQuery
: IQuery<Result<PagingSortingFiltering<Cairo202320240721mergeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllCairo202320240721mergeQueryHandler :
    IQueryHandler<GetAllCairo202320240721mergeQuery,
        Result<PagingSortingFiltering<Cairo202320240721mergeDetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllCairo202320240721mergeQueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<Cairo202320240721mergeDetailsResponse>>> Handle(
        GetAllCairo202320240721mergeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _db.Cairo202320240721merges
                            .AsNoTracking()
                            .ProjectToType<Cairo202320240721mergeDetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<Cairo202320240721mergeDetailsResponse>>.Success(result);
    }
}
