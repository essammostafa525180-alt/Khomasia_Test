using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.Sheet1;

public class GetAllSheet1Query
: IQuery<Result<PagingSortingFiltering<Sheet1DetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllSheet1QueryHandler :
    IQueryHandler<GetAllSheet1Query,
        Result<PagingSortingFiltering<Sheet1DetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllSheet1QueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<Sheet1DetailsResponse>>> Handle(
        GetAllSheet1Query request,
        CancellationToken cancellationToken)
    {
        var result = await _db.Sheet1s
                            .AsNoTracking()
                            .ProjectToType<Sheet1DetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<Sheet1DetailsResponse>>.Success(result);
    }
}
