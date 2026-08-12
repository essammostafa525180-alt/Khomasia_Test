using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItemLocationDetail.Queries;

public class GetAllInventoryItemLocationDetailQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemLocationDetailDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemLocationDetailQueryHandler :
    IQueryHandler<GetAllInventoryItemLocationDetailQuery,
        Result<PagingSortingFiltering<InventoryItemLocationDetailDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemLocationDetailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemLocationDetailDetailsResponse>>> Handle(
        GetAllInventoryItemLocationDetailQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryItemLocationDetailRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryItemLocationDetailDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemLocationDetailDetailsResponse>>.Success(result);
    }
}