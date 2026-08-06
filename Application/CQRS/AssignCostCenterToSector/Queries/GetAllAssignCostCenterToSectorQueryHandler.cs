using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssignCostCenterToSector.Queries;

public class GetAllAssignCostCenterToSectorQuery
: IQuery<Result<PagingSortingFiltering<AssignCostCenterToSectorDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssignCostCenterToSectorQueryHandler :
    IQueryHandler<GetAllAssignCostCenterToSectorQuery,
        Result<PagingSortingFiltering<AssignCostCenterToSectorDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssignCostCenterToSectorQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssignCostCenterToSectorDetailsResponse>>> Handle(
        GetAllAssignCostCenterToSectorQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssignCostCenterToSectorRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssignCostCenterToSectorDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssignCostCenterToSectorDetailsResponse>>.Success(result);
    }
}