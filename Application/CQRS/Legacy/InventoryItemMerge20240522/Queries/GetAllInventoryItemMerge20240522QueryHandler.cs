using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.InventoryItemMerge20240522;

public class GetAllInventoryItemMerge20240522Query
: IQuery<Result<PagingSortingFiltering<InventoryItemMerge20240522DetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemMerge20240522QueryHandler :
    IQueryHandler<GetAllInventoryItemMerge20240522Query,
        Result<PagingSortingFiltering<InventoryItemMerge20240522DetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllInventoryItemMerge20240522QueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemMerge20240522DetailsResponse>>> Handle(
        GetAllInventoryItemMerge20240522Query request,
        CancellationToken cancellationToken)
    {
        var result = await _db.InventoryItemMerge20240522s
                            .AsNoTracking()
                            .ProjectToType<InventoryItemMerge20240522DetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemMerge20240522DetailsResponse>>.Success(result);
    }
}
