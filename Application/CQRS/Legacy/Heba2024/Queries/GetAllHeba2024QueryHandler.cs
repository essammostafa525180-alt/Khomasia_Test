using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.Heba2024;

public class GetAllHeba2024Query
: IQuery<Result<PagingSortingFiltering<Heba2024DetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllHeba2024QueryHandler :
    IQueryHandler<GetAllHeba2024Query,
        Result<PagingSortingFiltering<Heba2024DetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllHeba2024QueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<Heba2024DetailsResponse>>> Handle(
        GetAllHeba2024Query request,
        CancellationToken cancellationToken)
    {
        var result = await _db.Heba2024s
                            .AsNoTracking()
                            .ProjectToType<Heba2024DetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<Heba2024DetailsResponse>>.Success(result);
    }
}
