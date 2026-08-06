using Application.Abstractions;

namespace Application.CQRS.AssignVendorEvaluationCriterion.Commands;

public class CreateAssignVendorEvaluationCriterionCommand : ICommand<Result<int>>
{
        public int? VendorFk { get; set; }
        public int? VendorEvaluationCriteriaFk { get; set; }
        public int? RankFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssignVendorEvaluationCriterionCommandHandler : ICommandHandler<CreateAssignVendorEvaluationCriterionCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssignVendorEvaluationCriterionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssignVendorEvaluationCriterionCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VendorAggregate.AssignVendorEvaluationCriterion.Create(request.VendorFk, request.VendorEvaluationCriteriaFk, request.RankFk, request.IsActive);

        await _unitOfWork.AssignVendorEvaluationCriterionRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssignVendorEvaluationCriterionNotInserted);
    }
}