using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorOrder.Queries;

public class GetAllVendorOrderQuery
: IQuery<Result<PagingSortingFiltering<VendorOrderDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorOrderQueryHandler :
    IQueryHandler<GetAllVendorOrderQuery,
        Result<PagingSortingFiltering<VendorOrderDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorOrderQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorOrderDetailsResponse>>> Handle(
        GetAllVendorOrderQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorOrderRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorOrderDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorOrderDetailsResponse>>.Success(result);
    }
}