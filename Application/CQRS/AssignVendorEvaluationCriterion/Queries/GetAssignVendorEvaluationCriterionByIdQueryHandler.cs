using Application.Abstractions;
using Mapster;

namespace Application.CQRS.AssignVendorEvaluationCriterion.Queries;

public class GetAssignVendorEvaluationCriterionByIdQuery : IQuery<Result<AssignVendorEvaluationCriterionDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetAssignVendorEvaluationCriterionByIdQueryHandler : IQueryHandler<GetAssignVendorEvaluationCriterionByIdQuery, Result<AssignVendorEvaluationCriterionDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssignVendorEvaluationCriterionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AssignVendorEvaluationCriterionDetailsResponse>> Handle(GetAssignVendorEvaluationCriterionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssignVendorEvaluationCriterionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<AssignVendorEvaluationCriterionDetailsResponse>.Failure(Errors.AssignVendorEvaluationCriterionNotFound);

        var response = entity.Adapt<AssignVendorEvaluationCriterionDetailsResponse>();

        return Result<AssignVendorEvaluationCriterionDetailsResponse>.Success(response);
    }
}