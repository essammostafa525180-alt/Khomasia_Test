using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorOrderReceiveSerial.Queries;

public class GetAllVendorOrderReceiveSerialQuery
: IQuery<Result<PagingSortingFiltering<VendorOrderReceiveSerialDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorOrderReceiveSerialQueryHandler :
    IQueryHandler<GetAllVendorOrderReceiveSerialQuery,
        Result<PagingSortingFiltering<VendorOrderReceiveSerialDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorOrderReceiveSerialQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorOrderReceiveSerialDetailsResponse>>> Handle(
        GetAllVendorOrderReceiveSerialQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorOrderReceiveSerialRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorOrderReceiveSerialDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorOrderReceiveSerialDetailsResponse>>.Success(result);
    }
}