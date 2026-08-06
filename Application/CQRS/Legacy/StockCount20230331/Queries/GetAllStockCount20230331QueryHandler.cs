using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.StockCount20230331;

public class GetAllStockCount20230331Query
: IQuery<Result<PagingSortingFiltering<StockCount20230331DetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllStockCount20230331QueryHandler :
    IQueryHandler<GetAllStockCount20230331Query,
        Result<PagingSortingFiltering<StockCount20230331DetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllStockCount20230331QueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<StockCount20230331DetailsResponse>>> Handle(
        GetAllStockCount20230331Query request,
        CancellationToken cancellationToken)
    {
        var result = await _db.StockCount20230331s
                            .AsNoTracking()
                            .ProjectToType<StockCount20230331DetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<StockCount20230331DetailsResponse>>.Success(result);
    }
}
