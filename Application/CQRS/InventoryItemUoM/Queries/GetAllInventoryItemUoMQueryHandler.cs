using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItemUoM.Queries;

public class GetAllInventoryItemUoMQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemUoMDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemUoMQueryHandler :
    IQueryHandler<GetAllInventoryItemUoMQuery,
        Result<PagingSortingFiltering<InventoryItemUoMDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemUoMQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemUoMDetailsResponse>>> Handle(
        GetAllInventoryItemUoMQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryItemUoMRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryItemUoMDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemUoMDetailsResponse>>.Success(result);
    }
}