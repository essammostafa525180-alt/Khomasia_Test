using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssignVendorSpecialization.Queries;

public class GetAllAssignVendorSpecializationQuery
: IQuery<Result<PagingSortingFiltering<AssignVendorSpecializationDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssignVendorSpecializationQueryHandler :
    IQueryHandler<GetAllAssignVendorSpecializationQuery,
        Result<PagingSortingFiltering<AssignVendorSpecializationDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssignVendorSpecializationQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssignVendorSpecializationDetailsResponse>>> Handle(
        GetAllAssignVendorSpecializationQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssignVendorSpecializationRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssignVendorSpecializationDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssignVendorSpecializationDetailsResponse>>.Success(result);
    }
}