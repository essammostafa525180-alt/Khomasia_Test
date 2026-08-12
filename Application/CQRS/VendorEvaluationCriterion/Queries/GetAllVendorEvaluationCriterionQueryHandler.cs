using Application.Abstractions;
using Application.Extensions;
using Application.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.VendorEvaluationCriterion.Queries;

public class GetAllVendorEvaluationCriterionQuery
: IQuery<Result<PagingSortingFiltering<VendorEvaluationCriterionDetailsResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class GetAllVendorEvaluationCriterionQueryHandler :
    IQueryHandler<GetAllVendorEvaluationCriterionQuery,
        Result<PagingSortingFiltering<VendorEvaluationCriterionDetailsResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVendorEvaluationCriterionQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagingSortingFiltering<VendorEvaluationCriterionDetailsResponse>>> Handle(
        GetAllVendorEvaluationCriterionQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.VendorEvaluationCriterionRepository.GetQueryable()
                                    .AsNoTracking()
                                    .ProjectToType<VendorEvaluationCriterionDetailsResponse>()
                                    .PagingAsync(request.PageNumber, request.PageSize, cancellationToken);

        return Result<PagingSortingFiltering<VendorEvaluationCriterionDetailsResponse>>.Success(result);
    }
}