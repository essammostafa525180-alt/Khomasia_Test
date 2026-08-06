using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Legacy._20230515HebaOpeningBalance;

public class GetAll_20230515HebaOpeningBalanceQuery
: IQuery<Result<PagingSortingFiltering<_20230515HebaOpeningBalanceDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAll_20230515HebaOpeningBalanceQueryHandler :
    IQueryHandler<GetAll_20230515HebaOpeningBalanceQuery,
        Result<PagingSortingFiltering<_20230515HebaOpeningBalanceDetailsResponse>>>
{
    private readonly IApplicationDbContext _db;

    public GetAll_20230515HebaOpeningBalanceQueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Result<PagingSortingFiltering<_20230515HebaOpeningBalanceDetailsResponse>>> Handle(
        GetAll_20230515HebaOpeningBalanceQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _db._20230515HebaOpeningBalances
                            .AsNoTracking()
                            .ProjectToType<_20230515HebaOpeningBalanceDetailsResponse>()
                            .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<_20230515HebaOpeningBalanceDetailsResponse>>.Success(result);
    }
}
