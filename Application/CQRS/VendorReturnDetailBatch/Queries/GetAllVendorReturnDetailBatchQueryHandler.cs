using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorReturnDetailBatch.Queries;

public class GetAllVendorReturnDetailBatchQuery
: IQuery<Result<PagingSortingFiltering<VendorReturnDetailBatchDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorReturnDetailBatchQueryHandler :
    IQueryHandler<GetAllVendorReturnDetailBatchQuery,
        Result<PagingSortingFiltering<VendorReturnDetailBatchDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorReturnDetailBatchQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorReturnDetailBatchDetailsResponse>>> Handle(
        GetAllVendorReturnDetailBatchQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorReturnDetailBatchRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorReturnDetailBatchDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorReturnDetailBatchDetailsResponse>>.Success(result);
    }
}