using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorReturnDetail.Queries;

public class GetAllVendorReturnDetailQuery
: IQuery<Result<PagingSortingFiltering<VendorReturnDetailDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorReturnDetailQueryHandler :
    IQueryHandler<GetAllVendorReturnDetailQuery,
        Result<PagingSortingFiltering<VendorReturnDetailDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorReturnDetailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorReturnDetailDetailsResponse>>> Handle(
        GetAllVendorReturnDetailQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorReturnDetailRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorReturnDetailDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorReturnDetailDetailsResponse>>.Success(result);
    }
}