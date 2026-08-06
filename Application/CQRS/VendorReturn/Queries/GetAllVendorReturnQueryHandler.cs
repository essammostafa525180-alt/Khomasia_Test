using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorReturn.Queries;

public class GetAllVendorReturnQuery
: IQuery<Result<PagingSortingFiltering<VendorReturnDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorReturnQueryHandler :
    IQueryHandler<GetAllVendorReturnQuery,
        Result<PagingSortingFiltering<VendorReturnDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorReturnQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorReturnDetailsResponse>>> Handle(
        GetAllVendorReturnQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorReturnRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorReturnDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorReturnDetailsResponse>>.Success(result);
    }
}