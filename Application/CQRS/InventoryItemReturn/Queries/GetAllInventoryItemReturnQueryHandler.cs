using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItemReturn.Queries;

public class GetAllInventoryItemReturnQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemReturnDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemReturnQueryHandler :
    IQueryHandler<GetAllInventoryItemReturnQuery,
        Result<PagingSortingFiltering<InventoryItemReturnDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemReturnQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemReturnDetailsResponse>>> Handle(
        GetAllInventoryItemReturnQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryItemReturnRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryItemReturnDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemReturnDetailsResponse>>.Success(result);
    }
}