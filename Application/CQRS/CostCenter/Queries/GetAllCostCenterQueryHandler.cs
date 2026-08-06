using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.CostCenter.Queries;

public class GetAllCostCenterQuery
: IQuery<Result<PagingSortingFiltering<CostCenterDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllCostCenterQueryHandler :
    IQueryHandler<GetAllCostCenterQuery,
        Result<PagingSortingFiltering<CostCenterDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCostCenterQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<CostCenterDetailsResponse>>> Handle(
        GetAllCostCenterQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.CostCenterRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<CostCenterDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<CostCenterDetailsResponse>>.Success(result);
    }
}