using Application.Abstractions;

namespace Application.CQRS.SecUserSecurableValue.Commands;

public class CreateSecUserSecurableValueCommand : ICommand<Result<int>>
{
        public string? Value { get; set; }
        public int? SecUserPropertyId { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSecUserSecurableValueCommandHandler : ICommandHandler<CreateSecUserSecurableValueCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSecUserSecurableValueCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSecUserSecurableValueCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.SecurityAggregate.SecUserSecurableValue.Create(request.Value, request.SecUserPropertyId, request.IsActive);

        await _unitOfWork.SecUserSecurableValueRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SecUserSecurableValueNotInserted);
    }
}