using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.Temp;

public class GetAllTempQuery
: IQuery<Result<PagingSortingFiltering<TempDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllTempQueryHandler :
    IQueryHandler<GetAllTempQuery,
        Result<PagingSortingFiltering<TempDetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllTempQueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<TempDetailsResponse>>> Handle(
        GetAllTempQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _db.Temps
                            .AsNoTracking()
                            .ProjectToType<TempDetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<TempDetailsResponse>>.Success(result);
    }
}
