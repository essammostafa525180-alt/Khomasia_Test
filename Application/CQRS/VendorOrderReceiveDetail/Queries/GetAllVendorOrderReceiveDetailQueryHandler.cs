using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorOrderReceiveDetail.Queries;

public class GetAllVendorOrderReceiveDetailQuery
: IQuery<Result<PagingSortingFiltering<VendorOrderReceiveDetailDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorOrderReceiveDetailQueryHandler :
    IQueryHandler<GetAllVendorOrderReceiveDetailQuery,
        Result<PagingSortingFiltering<VendorOrderReceiveDetailDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorOrderReceiveDetailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorOrderReceiveDetailDetailsResponse>>> Handle(
        GetAllVendorOrderReceiveDetailQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorOrderReceiveDetailRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorOrderReceiveDetailDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorOrderReceiveDetailDetailsResponse>>.Success(result);
    }
}