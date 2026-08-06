using Application.Abstractions;

namespace Application.CQRS.AssignVendorEvaluationCriterion.Commands;

public class DeleteAssignVendorEvaluationCriterionCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssignVendorEvaluationCriterionCommandHandler : ICommandHandler<DeleteAssignVendorEvaluationCriterionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssignVendorEvaluationCriterionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssignVendorEvaluationCriterionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssignVendorEvaluationCriterionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssignVendorEvaluationCriterionNotFound);

        _unitOfWork.AssignVendorEvaluationCriterionRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssignVendorEvaluationCriterionNotDeleted);
    }
}