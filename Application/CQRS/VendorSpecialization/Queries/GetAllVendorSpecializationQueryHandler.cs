using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorSpecialization.Queries;

public class GetAllVendorSpecializationQuery
: IQuery<Result<PagingSortingFiltering<VendorSpecializationDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorSpecializationQueryHandler :
    IQueryHandler<GetAllVendorSpecializationQuery,
        Result<PagingSortingFiltering<VendorSpecializationDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorSpecializationQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorSpecializationDetailsResponse>>> Handle(
        GetAllVendorSpecializationQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorSpecializationRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorSpecializationDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorSpecializationDetailsResponse>>.Success(result);
    }
}