using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorOrderReceiveDetailBatchSerial.Queries;

public class GetAllVendorOrderReceiveDetailBatchSerialQuery
: IQuery<Result<PagingSortingFiltering<VendorOrderReceiveDetailBatchSerialDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorOrderReceiveDetailBatchSerialQueryHandler :
    IQueryHandler<GetAllVendorOrderReceiveDetailBatchSerialQuery,
        Result<PagingSortingFiltering<VendorOrderReceiveDetailBatchSerialDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorOrderReceiveDetailBatchSerialQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorOrderReceiveDetailBatchSerialDetailsResponse>>> Handle(
        GetAllVendorOrderReceiveDetailBatchSerialQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorOrderReceiveDetailBatchSerialRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorOrderReceiveDetailBatchSerialDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorOrderReceiveDetailBatchSerialDetailsResponse>>.Success(result);
    }
}