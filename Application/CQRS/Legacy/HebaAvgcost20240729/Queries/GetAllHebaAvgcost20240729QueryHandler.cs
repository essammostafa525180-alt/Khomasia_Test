using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.HebaAvgcost20240729;

public class GetAllHebaAvgcost20240729Query
: IQuery<Result<PagingSortingFiltering<HebaAvgcost20240729DetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllHebaAvgcost20240729QueryHandler :
    IQueryHandler<GetAllHebaAvgcost20240729Query,
        Result<PagingSortingFiltering<HebaAvgcost20240729DetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllHebaAvgcost20240729QueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<HebaAvgcost20240729DetailsResponse>>> Handle(
        GetAllHebaAvgcost20240729Query request,
        CancellationToken cancellationToken)
    {
        var result = await _db.HebaAvgcost20240729s
                            .AsNoTracking()
                            .ProjectToType<HebaAvgcost20240729DetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<HebaAvgcost20240729DetailsResponse>>.Success(result);
    }
}
