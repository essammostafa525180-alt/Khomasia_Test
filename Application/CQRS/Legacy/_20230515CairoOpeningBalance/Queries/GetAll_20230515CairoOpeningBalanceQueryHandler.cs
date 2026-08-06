using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy._20230515CairoOpeningBalance;

public class GetAll_20230515CairoOpeningBalanceQuery
: IQuery<Result<PagingSortingFiltering<_20230515CairoOpeningBalanceDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAll_20230515CairoOpeningBalanceQueryHandler :
    IQueryHandler<GetAll_20230515CairoOpeningBalanceQuery,
        Result<PagingSortingFiltering<_20230515CairoOpeningBalanceDetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAll_20230515CairoOpeningBalanceQueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<_20230515CairoOpeningBalanceDetailsResponse>>> Handle(
        GetAll_20230515CairoOpeningBalanceQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _db._20230515CairoOpeningBalances
                            .AsNoTracking()
                            .ProjectToType<_20230515CairoOpeningBalanceDetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<_20230515CairoOpeningBalanceDetailsResponse>>.Success(result);
    }
}
