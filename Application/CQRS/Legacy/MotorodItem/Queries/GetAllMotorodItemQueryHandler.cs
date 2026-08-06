using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.MotorodItem;

public class GetAllMotorodItemQuery
: IQuery<Result<PagingSortingFiltering<MotorodItemDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllMotorodItemQueryHandler :
    IQueryHandler<GetAllMotorodItemQuery,
        Result<PagingSortingFiltering<MotorodItemDetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllMotorodItemQueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<MotorodItemDetailsResponse>>> Handle(
        GetAllMotorodItemQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _db.MotorodItems
                            .AsNoTracking()
                            .ProjectToType<MotorodItemDetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<MotorodItemDetailsResponse>>.Success(result);
    }
}
