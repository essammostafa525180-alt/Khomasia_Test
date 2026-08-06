using Application.Abstractions;

namespace Application.CQRS.SecUserProperty.Commands;

public class CreateSecUserPropertyCommand : ICommand<Result<int>>
{
        public int? UserId { get; set; }
        public int? PropertyId { get; set; }
        public int? Mode { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSecUserPropertyCommandHandler : ICommandHandler<CreateSecUserPropertyCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSecUserPropertyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSecUserPropertyCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.SecurityAggregate.SecUserProperty.Create(request.UserId, request.PropertyId, request.Mode, request.IsActive);

        await _unitOfWork.SecUserPropertyRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SecUserPropertyNotInserted);
    }
}