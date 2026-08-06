using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorType.Queries;

public class GetAllVendorTypeQuery
: IQuery<Result<PagingSortingFiltering<VendorTypeDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorTypeQueryHandler :
    IQueryHandler<GetAllVendorTypeQuery,
        Result<PagingSortingFiltering<VendorTypeDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorTypeDetailsResponse>>> Handle(
        GetAllVendorTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorTypeRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorTypeDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorTypeDetailsResponse>>.Success(result);
    }
}