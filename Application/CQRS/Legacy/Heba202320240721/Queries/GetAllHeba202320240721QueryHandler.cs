using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.Heba202320240721;

public class GetAllHeba202320240721Query
: IQuery<Result<PagingSortingFiltering<Heba202320240721DetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllHeba202320240721QueryHandler :
    IQueryHandler<GetAllHeba202320240721Query,
        Result<PagingSortingFiltering<Heba202320240721DetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllHeba202320240721QueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<Heba202320240721DetailsResponse>>> Handle(
        GetAllHeba202320240721Query request,
        CancellationToken cancellationToken)
    {
        var result = await _db.Heba202320240721s
                            .AsNoTracking()
                            .ProjectToType<Heba202320240721DetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<Heba202320240721DetailsResponse>>.Success(result);
    }
}
