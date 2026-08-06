using Application.Abstractions;

namespace Application.CQRS.SecRoleSecurableValue.Commands;

public class CreateSecRoleSecurableValueCommand : ICommand<Result<int>>
{
        public string? Value { get; set; }
        public int? SecRolePropertyId { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSecRoleSecurableValueCommandHandler : ICommandHandler<CreateSecRoleSecurableValueCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSecRoleSecurableValueCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSecRoleSecurableValueCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.SecurityAggregate.SecRoleSecurableValue.Create(request.Value, request.SecRolePropertyId, request.IsActive);

        await _unitOfWork.SecRoleSecurableValueRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SecRoleSecurableValueNotInserted);
    }
}