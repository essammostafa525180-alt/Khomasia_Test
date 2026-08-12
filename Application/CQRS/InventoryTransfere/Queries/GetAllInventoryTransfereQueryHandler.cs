using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryTransfere.Queries;

public class GetAllInventoryTransfereQuery
: IQuery<Result<PagingSortingFiltering<InventoryTransfereDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryTransfereQueryHandler :
    IQueryHandler<GetAllInventoryTransfereQuery,
        Result<PagingSortingFiltering<InventoryTransfereDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryTransfereQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryTransfereDetailsResponse>>> Handle(
        GetAllInventoryTransfereQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryTransfereRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryTransfereDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryTransfereDetailsResponse>>.Success(result);
    }
}