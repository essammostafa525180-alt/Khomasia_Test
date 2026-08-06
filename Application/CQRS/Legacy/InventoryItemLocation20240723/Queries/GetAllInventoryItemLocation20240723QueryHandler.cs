using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.InventoryItemLocation20240723;

public class GetAllInventoryItemLocation20240723Query
: IQuery<Result<PagingSortingFiltering<InventoryItemLocation20240723DetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemLocation20240723QueryHandler :
    IQueryHandler<GetAllInventoryItemLocation20240723Query,
        Result<PagingSortingFiltering<InventoryItemLocation20240723DetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllInventoryItemLocation20240723QueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemLocation20240723DetailsResponse>>> Handle(
        GetAllInventoryItemLocation20240723Query request,
        CancellationToken cancellationToken)
    {
        var result = await _db.InventoryItemLocation20240723s
                            .AsNoTracking()
                            .ProjectToType<InventoryItemLocation20240723DetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemLocation20240723DetailsResponse>>.Success(result);
    }
}
