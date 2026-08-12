using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.NotFoundItem;

public class GetAllNotFoundItemQuery
: IQuery<Result<PagingSortingFiltering<NotFoundItemDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllNotFoundItemQueryHandler :
    IQueryHandler<GetAllNotFoundItemQuery,
        Result<PagingSortingFiltering<NotFoundItemDetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllNotFoundItemQueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<NotFoundItemDetailsResponse>>> Handle(
        GetAllNotFoundItemQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _db.NotFoundItems
                            .AsNoTracking()
                            .ProjectToType<NotFoundItemDetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<NotFoundItemDetailsResponse>>.Success(result);
    }
}
