using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorReturnSerial.Queries;

public class GetAllVendorReturnSerialQuery
: IQuery<Result<PagingSortingFiltering<VendorReturnSerialDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorReturnSerialQueryHandler :
    IQueryHandler<GetAllVendorReturnSerialQuery,
        Result<PagingSortingFiltering<VendorReturnSerialDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorReturnSerialQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorReturnSerialDetailsResponse>>> Handle(
        GetAllVendorReturnSerialQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorReturnSerialRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorReturnSerialDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorReturnSerialDetailsResponse>>.Success(result);
    }
}