using Application.Abstractions;
using Mapster;

namespace Application.CQRS.VendorEvaluationCriterion.Queries;

public class GetVendorEvaluationCriterionByIdQuery : IQuery<Result<VendorEvaluationCriterionDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetVendorEvaluationCriterionByIdQueryHandler : IQueryHandler<GetVendorEvaluationCriterionByIdQuery, Result<VendorEvaluationCriterionDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVendorEvaluationCriterionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VendorEvaluationCriterionDetailsResponse>> Handle(GetVendorEvaluationCriterionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorEvaluationCriterionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<VendorEvaluationCriterionDetailsResponse>.Failure(Errors.VendorEvaluationCriterionNotFound);

        var response = entity.Adapt<VendorEvaluationCriterionDetailsResponse>();

        return Result<VendorEvaluationCriterionDetailsResponse>.Success(response);
    }
}