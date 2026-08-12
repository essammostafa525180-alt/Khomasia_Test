using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorOrderVendorSuggested.Queries;

public class GetAllVendorOrderVendorSuggestedQuery
: IQuery<Result<PagingSortingFiltering<VendorOrderVendorSuggestedDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorOrderVendorSuggestedQueryHandler :
    IQueryHandler<GetAllVendorOrderVendorSuggestedQuery,
        Result<PagingSortingFiltering<VendorOrderVendorSuggestedDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorOrderVendorSuggestedQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorOrderVendorSuggestedDetailsResponse>>> Handle(
        GetAllVendorOrderVendorSuggestedQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorOrderVendorSuggestedRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorOrderVendorSuggestedDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorOrderVendorSuggestedDetailsResponse>>.Success(result);
    }
}