using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorOrderReceive.Queries;

public class GetAllVendorOrderReceiveQuery
: IQuery<Result<PagingSortingFiltering<VendorOrderReceiveDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorOrderReceiveQueryHandler :
    IQueryHandler<GetAllVendorOrderReceiveQuery,
        Result<PagingSortingFiltering<VendorOrderReceiveDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorOrderReceiveQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorOrderReceiveDetailsResponse>>> Handle(
        GetAllVendorOrderReceiveQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorOrderReceiveRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorOrderReceiveDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorOrderReceiveDetailsResponse>>.Success(result);
    }
}