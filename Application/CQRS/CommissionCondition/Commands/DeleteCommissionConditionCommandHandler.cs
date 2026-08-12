using Application.Abstractions;

namespace Application.CQRS.CommissionCondition.Commands;

public class DeleteCommissionConditionCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteCommissionConditionCommandHandler : ICommandHandler<DeleteCommissionConditionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCommissionConditionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteCommissionConditionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CommissionConditionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.CommissionConditionNotFound);

        _unitOfWork.CommissionConditionRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.CommissionConditionNotDeleted);
    }
}