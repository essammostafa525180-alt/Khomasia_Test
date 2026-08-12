using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorOrderReceiveDetailBatch.Queries;

public class GetAllVendorOrderReceiveDetailBatchQuery
: IQuery<Result<PagingSortingFiltering<VendorOrderReceiveDetailBatchDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorOrderReceiveDetailBatchQueryHandler :
    IQueryHandler<GetAllVendorOrderReceiveDetailBatchQuery,
        Result<PagingSortingFiltering<VendorOrderReceiveDetailBatchDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorOrderReceiveDetailBatchQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorOrderReceiveDetailBatchDetailsResponse>>> Handle(
        GetAllVendorOrderReceiveDetailBatchQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorOrderReceiveDetailBatchRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorOrderReceiveDetailBatchDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorOrderReceiveDetailBatchDetailsResponse>>.Success(result);
    }
}