using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AnnualStockCountItemMerge.Queries;

public class GetAllAnnualStockCountItemMergeQuery
: IQuery<Result<PagingSortingFiltering<AnnualStockCountItemMergeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAnnualStockCountItemMergeQueryHandler :
    IQueryHandler<GetAllAnnualStockCountItemMergeQuery,
        Result<PagingSortingFiltering<AnnualStockCountItemMergeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAnnualStockCountItemMergeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AnnualStockCountItemMergeDetailsResponse>>> Handle(
        GetAllAnnualStockCountItemMergeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AnnualStockCountItemMergeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AnnualStockCountItemMergeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AnnualStockCountItemMergeDetailsResponse>>.Success(result);
    }
}