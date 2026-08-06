using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.CommissionCondition.Queries;

public class GetAllCommissionConditionQuery
: IQuery<Result<PagingSortingFiltering<CommissionConditionDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllCommissionConditionQueryHandler :
    IQueryHandler<GetAllCommissionConditionQuery,
        Result<PagingSortingFiltering<CommissionConditionDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCommissionConditionQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<CommissionConditionDetailsResponse>>> Handle(
        GetAllCommissionConditionQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.CommissionConditionRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<CommissionConditionDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<CommissionConditionDetailsResponse>>.Success(result);
    }
}