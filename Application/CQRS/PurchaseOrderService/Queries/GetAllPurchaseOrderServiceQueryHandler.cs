using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.PurchaseOrderService.Queries;

public class GetAllPurchaseOrderServiceQuery
: IQuery<Result<PagingSortingFiltering<PurchaseOrderServiceDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllPurchaseOrderServiceQueryHandler :
    IQueryHandler<GetAllPurchaseOrderServiceQuery,
        Result<PagingSortingFiltering<PurchaseOrderServiceDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPurchaseOrderServiceQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<PurchaseOrderServiceDetailsResponse>>> Handle(
        GetAllPurchaseOrderServiceQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.PurchaseOrderServiceRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<PurchaseOrderServiceDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<PurchaseOrderServiceDetailsResponse>>.Success(result);
    }
}