using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.CairoAvgcost20240729;

public class GetAllCairoAvgcost20240729Query
: IQuery<Result<PagingSortingFiltering<CairoAvgcost20240729DetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllCairoAvgcost20240729QueryHandler :
    IQueryHandler<GetAllCairoAvgcost20240729Query,
        Result<PagingSortingFiltering<CairoAvgcost20240729DetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllCairoAvgcost20240729QueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<CairoAvgcost20240729DetailsResponse>>> Handle(
        GetAllCairoAvgcost20240729Query request,
        CancellationToken cancellationToken)
    {
        var result = await _db.CairoAvgcost20240729s
                            .AsNoTracking()
                            .ProjectToType<CairoAvgcost20240729DetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<CairoAvgcost20240729DetailsResponse>>.Success(result);
    }
}
