using Application.Abstractions;

namespace Application.CQRS.CommissionCondition.Commands;

public class CreateCommissionConditionCommand : ICommand<Result<int>>
{
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateCommissionConditionCommandHandler : ICommandHandler<CreateCommissionConditionCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCommissionConditionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateCommissionConditionCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.CommissionCondition.Create(request.Name, request.NameAr, request.IsActive);

        await _unitOfWork.CommissionConditionRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.CommissionConditionNotInserted);
    }
}