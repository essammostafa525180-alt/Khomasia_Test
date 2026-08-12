using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItemSerialStatus.Queries;

public class GetAllInventoryItemSerialStatusQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemSerialStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemSerialStatusQueryHandler :
    IQueryHandler<GetAllInventoryItemSerialStatusQuery,
        Result<PagingSortingFiltering<InventoryItemSerialStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemSerialStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemSerialStatusDetailsResponse>>> Handle(
        GetAllInventoryItemSerialStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryItemSerialStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryItemSerialStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemSerialStatusDetailsResponse>>.Success(result);
    }
}