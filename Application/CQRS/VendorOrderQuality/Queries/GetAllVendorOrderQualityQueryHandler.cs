using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorOrderQuality.Queries;

public class GetAllVendorOrderQualityQuery
: IQuery<Result<PagingSortingFiltering<VendorOrderQualityDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorOrderQualityQueryHandler :
    IQueryHandler<GetAllVendorOrderQualityQuery,
        Result<PagingSortingFiltering<VendorOrderQualityDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorOrderQualityQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorOrderQualityDetailsResponse>>> Handle(
        GetAllVendorOrderQualityQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorOrderQualityRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorOrderQualityDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorOrderQualityDetailsResponse>>.Success(result);
    }
}