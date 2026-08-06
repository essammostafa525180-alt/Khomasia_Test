using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.InventoryItemMerge20240610;

public class GetAllInventoryItemMerge20240610Query
: IQuery<Result<PagingSortingFiltering<InventoryItemMerge20240610DetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemMerge20240610QueryHandler :
    IQueryHandler<GetAllInventoryItemMerge20240610Query,
        Result<PagingSortingFiltering<InventoryItemMerge20240610DetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllInventoryItemMerge20240610QueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemMerge20240610DetailsResponse>>> Handle(
        GetAllInventoryItemMerge20240610Query request,
        CancellationToken cancellationToken)
    {
        var result = await _db.InventoryItemMerge20240610s
                            .AsNoTracking()
                            .ProjectToType<InventoryItemMerge20240610DetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemMerge20240610DetailsResponse>>.Success(result);
    }
}
