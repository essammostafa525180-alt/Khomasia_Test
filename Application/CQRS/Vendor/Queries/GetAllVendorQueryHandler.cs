using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Vendor.Queries;

public class GetAllVendorQuery
: IQuery<Result<PagingSortingFiltering<VendorDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorQueryHandler :
    IQueryHandler<GetAllVendorQuery,
        Result<PagingSortingFiltering<VendorDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorDetailsResponse>>> Handle(
        GetAllVendorQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorDetailsResponse>>.Success(result);
    }
}