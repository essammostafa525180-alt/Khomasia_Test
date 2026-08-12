using Application.Abstractions;

namespace Application.CQRS.VendorEvaluationCriterion.Commands;

public class DeleteVendorEvaluationCriterionCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteVendorEvaluationCriterionCommandHandler : ICommandHandler<DeleteVendorEvaluationCriterionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVendorEvaluationCriterionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVendorEvaluationCriterionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.VendorEvaluationCriterionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.VendorEvaluationCriterionNotFound);

        _unitOfWork.VendorEvaluationCriterionRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.VendorEvaluationCriterionNotDeleted);
    }
}