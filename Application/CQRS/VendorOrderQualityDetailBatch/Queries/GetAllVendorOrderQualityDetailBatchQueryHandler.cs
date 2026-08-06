using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorOrderQualityDetailBatch.Queries;

public class GetAllVendorOrderQualityDetailBatchQuery
: IQuery<Result<PagingSortingFiltering<VendorOrderQualityDetailBatchDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorOrderQualityDetailBatchQueryHandler :
    IQueryHandler<GetAllVendorOrderQualityDetailBatchQuery,
        Result<PagingSortingFiltering<VendorOrderQualityDetailBatchDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorOrderQualityDetailBatchQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorOrderQualityDetailBatchDetailsResponse>>> Handle(
        GetAllVendorOrderQualityDetailBatchQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorOrderQualityDetailBatchRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorOrderQualityDetailBatchDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorOrderQualityDetailBatchDetailsResponse>>.Success(result);
    }
}