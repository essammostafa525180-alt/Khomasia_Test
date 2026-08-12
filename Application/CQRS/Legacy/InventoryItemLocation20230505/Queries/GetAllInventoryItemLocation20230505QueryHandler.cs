using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.InventoryItemLocation20230505;

public class GetAllInventoryItemLocation20230505Query
: IQuery<Result<PagingSortingFiltering<InventoryItemLocation20230505DetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemLocation20230505QueryHandler :
    IQueryHandler<GetAllInventoryItemLocation20230505Query,
        Result<PagingSortingFiltering<InventoryItemLocation20230505DetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllInventoryItemLocation20230505QueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemLocation20230505DetailsResponse>>> Handle(
        GetAllInventoryItemLocation20230505Query request,
        CancellationToken cancellationToken)
    {
        var result = await _db.InventoryItemLocation20230505s
                            .AsNoTracking()
                            .ProjectToType<InventoryItemLocation20230505DetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemLocation20230505DetailsResponse>>.Success(result);
    }
}
