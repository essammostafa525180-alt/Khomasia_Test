using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorOrderVendorSelection.Queries;

public class GetAllVendorOrderVendorSelectionQuery
: IQuery<Result<PagingSortingFiltering<VendorOrderVendorSelectionDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorOrderVendorSelectionQueryHandler :
    IQueryHandler<GetAllVendorOrderVendorSelectionQuery,
        Result<PagingSortingFiltering<VendorOrderVendorSelectionDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorOrderVendorSelectionQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorOrderVendorSelectionDetailsResponse>>> Handle(
        GetAllVendorOrderVendorSelectionQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorOrderVendorSelectionRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorOrderVendorSelectionDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorOrderVendorSelectionDetailsResponse>>.Success(result);
    }
}