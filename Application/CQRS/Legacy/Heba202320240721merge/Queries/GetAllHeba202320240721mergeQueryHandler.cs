using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.Heba202320240721merge;

public class GetAllHeba202320240721mergeQuery
: IQuery<Result<PagingSortingFiltering<Heba202320240721mergeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllHeba202320240721mergeQueryHandler :
    IQueryHandler<GetAllHeba202320240721mergeQuery,
        Result<PagingSortingFiltering<Heba202320240721mergeDetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllHeba202320240721mergeQueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<Heba202320240721mergeDetailsResponse>>> Handle(
        GetAllHeba202320240721mergeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _db.Heba202320240721merges
                            .AsNoTracking()
                            .ProjectToType<Heba202320240721mergeDetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<Heba202320240721mergeDetailsResponse>>.Success(result);
    }
}
