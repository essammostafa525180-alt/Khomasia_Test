using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryStockCountDetail.Queries;

public class GetAllInventoryStockCountDetailQuery
: IQuery<Result<PagingSortingFiltering<InventoryStockCountDetailDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryStockCountDetailQueryHandler :
    IQueryHandler<GetAllInventoryStockCountDetailQuery,
        Result<PagingSortingFiltering<InventoryStockCountDetailDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryStockCountDetailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryStockCountDetailDetailsResponse>>> Handle(
        GetAllInventoryStockCountDetailQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryStockCountDetailRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryStockCountDetailDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryStockCountDetailDetailsResponse>>.Success(result);
    }
}