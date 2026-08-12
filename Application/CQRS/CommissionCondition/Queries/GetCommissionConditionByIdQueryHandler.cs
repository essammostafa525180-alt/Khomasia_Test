using Application.Abstractions;
using Mapster;

namespace Application.CQRS.CommissionCondition.Queries;

public class GetCommissionConditionByIdQuery : IQuery<Result<CommissionConditionDetailsResponse>>
{
    public int Id { get; set; }
}
internal class GetCommissionConditionByIdQueryHandler : IQueryHandler<GetCommissionConditionByIdQuery, Result<CommissionConditionDetailsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCommissionConditionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CommissionConditionDetailsResponse>> Handle(GetCommissionConditionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CommissionConditionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result<CommissionConditionDetailsResponse>.Failure(Errors.CommissionConditionNotFound);

        var response = entity.Adapt<CommissionConditionDetailsResponse>();

        return Result<CommissionConditionDetailsResponse>.Success(response);
    }
}