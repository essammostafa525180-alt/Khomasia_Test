using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.InventoryItem2024;

public class GetAllInventoryItem2024Query
: IQuery<Result<PagingSortingFiltering<InventoryItem2024DetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItem2024QueryHandler :
    IQueryHandler<GetAllInventoryItem2024Query,
        Result<PagingSortingFiltering<InventoryItem2024DetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllInventoryItem2024QueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItem2024DetailsResponse>>> Handle(
        GetAllInventoryItem2024Query request,
        CancellationToken cancellationToken)
    {
        var result = await _db.InventoryItem2024s
                            .AsNoTracking()
                            .ProjectToType<InventoryItem2024DetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItem2024DetailsResponse>>.Success(result);
    }
}
