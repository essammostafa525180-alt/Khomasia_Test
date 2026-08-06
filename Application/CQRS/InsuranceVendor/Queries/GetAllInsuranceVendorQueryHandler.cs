using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.InsuranceVendor.Queries;

public class GetAllInsuranceVendorQuery
: IQuery<Result<PagingSortingFiltering<InsuranceVendorDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllInsuranceVendorQueryHandler :
    IQueryHandler<GetAllInsuranceVendorQuery,
        Result<PagingSortingFiltering<InsuranceVendorDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInsuranceVendorQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<InsuranceVendorDetailsResponse>>> Handle(
        GetAllInsuranceVendorQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.InsuranceVendorRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<InsuranceVendorDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<InsuranceVendorDetailsResponse>>.Success(result);
    }
}