using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.AssignVendorEvaluationCriterion.Queries;

public class GetAllAssignVendorEvaluationCriterionQuery
: IQuery<Result<PagingSortingFiltering<AssignVendorEvaluationCriterionDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllAssignVendorEvaluationCriterionQueryHandler :
    IQueryHandler<GetAllAssignVendorEvaluationCriterionQuery,
        Result<PagingSortingFiltering<AssignVendorEvaluationCriterionDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAssignVendorEvaluationCriterionQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<AssignVendorEvaluationCriterionDetailsResponse>>> Handle(
        GetAllAssignVendorEvaluationCriterionQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.AssignVendorEvaluationCriterionRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<AssignVendorEvaluationCriterionDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<AssignVendorEvaluationCriterionDetailsResponse>>.Success(result);
    }
}