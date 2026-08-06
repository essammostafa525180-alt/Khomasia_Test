using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorOrderType.Queries;

public class GetAllVendorOrderTypeQuery
: IQuery<Result<PagingSortingFiltering<VendorOrderTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorOrderTypeQueryHandler :
    IQueryHandler<GetAllVendorOrderTypeQuery,
        Result<PagingSortingFiltering<VendorOrderTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorOrderTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorOrderTypeDetailsResponse>>> Handle(
        GetAllVendorOrderTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorOrderTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorOrderTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorOrderTypeDetailsResponse>>.Success(result);
    }
}