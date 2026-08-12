using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.Cairo202320240721;

public class GetAllCairo202320240721Query
: IQuery<Result<PagingSortingFiltering<Cairo202320240721DetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllCairo202320240721QueryHandler :
    IQueryHandler<GetAllCairo202320240721Query,
        Result<PagingSortingFiltering<Cairo202320240721DetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllCairo202320240721QueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<Cairo202320240721DetailsResponse>>> Handle(
        GetAllCairo202320240721Query request,
        CancellationToken cancellationToken)
    {
        var result = await _db.Cairo202320240721s
                            .AsNoTracking()
                            .ProjectToType<Cairo202320240721DetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<Cairo202320240721DetailsResponse>>.Success(result);
    }
}
