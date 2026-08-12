using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.InventoryItemLocationDetail20240723;

public class GetAllInventoryItemLocationDetail20240723Query
: IQuery<Result<PagingSortingFiltering<InventoryItemLocationDetail20240723DetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemLocationDetail20240723QueryHandler :
    IQueryHandler<GetAllInventoryItemLocationDetail20240723Query,
        Result<PagingSortingFiltering<InventoryItemLocationDetail20240723DetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllInventoryItemLocationDetail20240723QueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemLocationDetail20240723DetailsResponse>>> Handle(
        GetAllInventoryItemLocationDetail20240723Query request,
        CancellationToken cancellationToken)
    {
        var result = await _db.InventoryItemLocationDetail20240723s
                            .AsNoTracking()
                            .ProjectToType<InventoryItemLocationDetail20240723DetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemLocationDetail20240723DetailsResponse>>.Success(result);
    }
}
