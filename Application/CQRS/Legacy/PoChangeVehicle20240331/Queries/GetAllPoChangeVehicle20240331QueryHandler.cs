using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.PoChangeVehicle20240331;

public class GetAllPoChangeVehicle20240331Query
: IQuery<Result<PagingSortingFiltering<PoChangeVehicle20240331DetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllPoChangeVehicle20240331QueryHandler :
    IQueryHandler<GetAllPoChangeVehicle20240331Query,
        Result<PagingSortingFiltering<PoChangeVehicle20240331DetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllPoChangeVehicle20240331QueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<PoChangeVehicle20240331DetailsResponse>>> Handle(
        GetAllPoChangeVehicle20240331Query request,
        CancellationToken cancellationToken)
    {
        var result = await _db.PoChangeVehicle20240331s
                            .AsNoTracking()
                            .ProjectToType<PoChangeVehicle20240331DetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<PoChangeVehicle20240331DetailsResponse>>.Success(result);
    }
}
