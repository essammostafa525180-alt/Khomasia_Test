using Application.Abstractions;

namespace Application.CQRS.CommissionCondition.Commands;

public class UpdateCommissionConditionCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateCommissionConditionCommandHandler : ICommandHandler<UpdateCommissionConditionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCommissionConditionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateCommissionConditionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CommissionConditionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.CommissionConditionNotFound);

        entity.Update(request.Name, request.NameAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.CommissionConditionNotUpdated);
    }
}