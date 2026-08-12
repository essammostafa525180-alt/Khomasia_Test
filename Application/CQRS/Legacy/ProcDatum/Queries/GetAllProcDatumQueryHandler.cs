using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy.ProcDatum;

public class GetAllProcDatumQuery
: IQuery<Result<PagingSortingFiltering<ProcDatumDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllProcDatumQueryHandler :
    IQueryHandler<GetAllProcDatumQuery,
        Result<PagingSortingFiltering<ProcDatumDetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAllProcDatumQueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<ProcDatumDetailsResponse>>> Handle(
        GetAllProcDatumQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _db.ProcData
                            .AsNoTracking()
                            .ProjectToType<ProcDatumDetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<ProcDatumDetailsResponse>>.Success(result);
    }
}
