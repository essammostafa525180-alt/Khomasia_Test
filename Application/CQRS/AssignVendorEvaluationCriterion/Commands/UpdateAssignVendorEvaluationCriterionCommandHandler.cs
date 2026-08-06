using Application.Abstractions;

namespace Application.CQRS.AssignVendorEvaluationCriterion.Commands;

public class UpdateAssignVendorEvaluationCriterionCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? VendorFk { get; set; }
        public int? VendorEvaluationCriteriaFk { get; set; }
        public int? RankFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssignVendorEvaluationCriterionCommandHandler : ICommandHandler<UpdateAssignVendorEvaluationCriterionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssignVendorEvaluationCriterionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssignVendorEvaluationCriterionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssignVendorEvaluationCriterionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssignVendorEvaluationCriterionNotFound);

        entity.Update(request.VendorFk, request.VendorEvaluationCriteriaFk, request.RankFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssignVendorEvaluationCriterionNotUpdated);
    }
}