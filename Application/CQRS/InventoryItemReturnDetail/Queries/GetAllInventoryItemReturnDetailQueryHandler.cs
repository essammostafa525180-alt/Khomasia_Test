using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItemReturnDetail.Queries;

public class GetAllInventoryItemReturnDetailQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemReturnDetailDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemReturnDetailQueryHandler :
    IQueryHandler<GetAllInventoryItemReturnDetailQuery,
        Result<PagingSortingFiltering<InventoryItemReturnDetailDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemReturnDetailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemReturnDetailDetailsResponse>>> Handle(
        GetAllInventoryItemReturnDetailQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryItemReturnDetailRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryItemReturnDetailDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemReturnDetailDetailsResponse>>.Success(result);
    }
}