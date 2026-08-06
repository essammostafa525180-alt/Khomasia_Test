using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InventoryItemVendor.Queries;

public class GetAllInventoryItemVendorQuery
: IQuery<Result<PagingSortingFiltering<InventoryItemVendorDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInventoryItemVendorQueryHandler :
    IQueryHandler<GetAllInventoryItemVendorQuery,
        Result<PagingSortingFiltering<InventoryItemVendorDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryItemVendorQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InventoryItemVendorDetailsResponse>>> Handle(
        GetAllInventoryItemVendorQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InventoryItemVendorRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InventoryItemVendorDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InventoryItemVendorDetailsResponse>>.Success(result);
    }
}