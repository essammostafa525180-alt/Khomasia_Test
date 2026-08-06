using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.Cairo2024;

public class GetAllCairo2024Query
: IQuery<Result<PagingSortingFiltering<Cairo2024DetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllCairo2024QueryHandler :
    IQueryHandler<GetAllCairo2024Query,
        Result<PagingSortingFiltering<Cairo2024DetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllCairo2024QueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<Cairo2024DetailsResponse>>> Handle(
        GetAllCairo2024Query request,
        CancellationToken cancellationToken)
    {
        var result = await _db.Cairo2024s
                            .AsNoTracking()
                            .ProjectToType<Cairo2024DetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<Cairo2024DetailsResponse>>.Success(result);
    }
}
