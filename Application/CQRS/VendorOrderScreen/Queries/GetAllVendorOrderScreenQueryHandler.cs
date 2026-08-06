using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorOrderScreen.Queries;

public class GetAllVendorOrderScreenQuery
: IQuery<Result<PagingSortingFiltering<VendorOrderScreenDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorOrderScreenQueryHandler :
    IQueryHandler<GetAllVendorOrderScreenQuery,
        Result<PagingSortingFiltering<VendorOrderScreenDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorOrderScreenQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorOrderScreenDetailsResponse>>> Handle(
        GetAllVendorOrderScreenQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorOrderScreenRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorOrderScreenDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorOrderScreenDetailsResponse>>.Success(result);
    }
}