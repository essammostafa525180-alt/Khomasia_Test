using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItemStatus.Queries;

public class GetAllInventoryItemStatusQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemStatusQueryHandler :
    IQueryHandler<GetAllInventoryItemStatusQuery,
        Result<PagingSortingFiltering<InventoryItemStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemStatusDetailsResponse>>> Handle(
        GetAllInventoryItemStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryItemStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryItemStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemStatusDetailsResponse>>.Success(result);
    }
}