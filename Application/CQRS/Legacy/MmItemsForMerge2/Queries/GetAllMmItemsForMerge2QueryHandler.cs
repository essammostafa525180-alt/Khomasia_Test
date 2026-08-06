using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.MmItemsForMerge2;

public class GetAllMmItemsForMerge2Query
: IQuery<Result<PagingSortingFiltering<MmItemsForMerge2DetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllMmItemsForMerge2QueryHandler :
    IQueryHandler<GetAllMmItemsForMerge2Query,
        Result<PagingSortingFiltering<MmItemsForMerge2DetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllMmItemsForMerge2QueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<MmItemsForMerge2DetailsResponse>>> Handle(
        GetAllMmItemsForMerge2Query request,
        CancellationToken cancellationToken)
    {
        var result = await _db.MmItemsForMerge2s
                            .AsNoTracking()
                            .ProjectToType<MmItemsForMerge2DetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<MmItemsForMerge2DetailsResponse>>.Success(result);
    }
}
