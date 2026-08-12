using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.InventoryItemLocation20230404;

public class GetAllInventoryItemLocation20230404Query
: IQuery<Result<PagingSortingFiltering<InventoryItemLocation20230404DetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemLocation20230404QueryHandler :
    IQueryHandler<GetAllInventoryItemLocation20230404Query,
        Result<PagingSortingFiltering<InventoryItemLocation20230404DetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllInventoryItemLocation20230404QueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemLocation20230404DetailsResponse>>> Handle(
        GetAllInventoryItemLocation20230404Query request,
        CancellationToken cancellationToken)
    {
        var result = await _db.InventoryItemLocation20230404s
                            .AsNoTracking()
                            .ProjectToType<InventoryItemLocation20230404DetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemLocation20230404DetailsResponse>>.Success(result);
    }
}
