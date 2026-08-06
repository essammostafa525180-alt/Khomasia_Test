using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AnnualStockCountItemQuantity.Queries;

public class GetAllAnnualStockCountItemQuantityQuery
: IQuery<Result<PagingSortingFiltering<AnnualStockCountItemQuantityDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAnnualStockCountItemQuantityQueryHandler :
    IQueryHandler<GetAllAnnualStockCountItemQuantityQuery,
        Result<PagingSortingFiltering<AnnualStockCountItemQuantityDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAnnualStockCountItemQuantityQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AnnualStockCountItemQuantityDetailsResponse>>> Handle(
        GetAllAnnualStockCountItemQuantityQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AnnualStockCountItemQuantityRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AnnualStockCountItemQuantityDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AnnualStockCountItemQuantityDetailsResponse>>.Success(result);
    }
}