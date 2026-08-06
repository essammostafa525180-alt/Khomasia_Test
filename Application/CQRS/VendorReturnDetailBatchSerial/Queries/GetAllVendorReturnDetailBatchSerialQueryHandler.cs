using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorReturnDetailBatchSerial.Queries;

public class GetAllVendorReturnDetailBatchSerialQuery
: IQuery<Result<PagingSortingFiltering<VendorReturnDetailBatchSerialDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorReturnDetailBatchSerialQueryHandler :
    IQueryHandler<GetAllVendorReturnDetailBatchSerialQuery,
        Result<PagingSortingFiltering<VendorReturnDetailBatchSerialDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorReturnDetailBatchSerialQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorReturnDetailBatchSerialDetailsResponse>>> Handle(
        GetAllVendorReturnDetailBatchSerialQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorReturnDetailBatchSerialRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorReturnDetailBatchSerialDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorReturnDetailBatchSerialDetailsResponse>>.Success(result);
    }
}