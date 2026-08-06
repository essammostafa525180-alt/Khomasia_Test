using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorOrderQualityDetail.Queries;

public class GetAllVendorOrderQualityDetailQuery
: IQuery<Result<PagingSortingFiltering<VendorOrderQualityDetailDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorOrderQualityDetailQueryHandler :
    IQueryHandler<GetAllVendorOrderQualityDetailQuery,
        Result<PagingSortingFiltering<VendorOrderQualityDetailDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorOrderQualityDetailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorOrderQualityDetailDetailsResponse>>> Handle(
        GetAllVendorOrderQualityDetailQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorOrderQualityDetailRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorOrderQualityDetailDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorOrderQualityDetailDetailsResponse>>.Success(result);
    }
}