using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorStatus.Queries;

public class GetAllVendorStatusQuery
: IQuery<Result<PagingSortingFiltering<VendorStatusDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorStatusQueryHandler :
    IQueryHandler<GetAllVendorStatusQuery,
        Result<PagingSortingFiltering<VendorStatusDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorStatusDetailsResponse>>> Handle(
        GetAllVendorStatusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorStatusRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorStatusDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorStatusDetailsResponse>>.Success(result);
    }
}