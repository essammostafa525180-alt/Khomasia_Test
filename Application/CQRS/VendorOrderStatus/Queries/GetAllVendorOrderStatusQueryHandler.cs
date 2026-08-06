using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorOrderStatus.Queries;

public class GetAllVendorOrderStatusQuery
: IQuery<Result<PagingSortingFiltering<VendorOrderStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorOrderStatusQueryHandler :
    IQueryHandler<GetAllVendorOrderStatusQuery,
        Result<PagingSortingFiltering<VendorOrderStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorOrderStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorOrderStatusDetailsResponse>>> Handle(
        GetAllVendorOrderStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorOrderStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorOrderStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorOrderStatusDetailsResponse>>.Success(result);
    }
}