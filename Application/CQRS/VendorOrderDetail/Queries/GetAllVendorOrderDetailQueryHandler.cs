using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorOrderDetail.Queries;

public class GetAllVendorOrderDetailQuery
: IQuery<Result<PagingSortingFiltering<VendorOrderDetailDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorOrderDetailQueryHandler :
    IQueryHandler<GetAllVendorOrderDetailQuery,
        Result<PagingSortingFiltering<VendorOrderDetailDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorOrderDetailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorOrderDetailDetailsResponse>>> Handle(
        GetAllVendorOrderDetailQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorOrderDetailRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorOrderDetailDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorOrderDetailDetailsResponse>>.Success(result);
    }
}