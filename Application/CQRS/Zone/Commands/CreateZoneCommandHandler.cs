using Application.Abstractions;

namespace Application.CQRS.Zone.Commands;

public class CreateZoneCommand : ICommand<Result<int>>
{
        public bool IsActive { get; set; }
}
internal class CreateZoneCommandHandler : ICommandHandler<CreateZoneCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateZoneCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateZoneCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.ZoneAggregate.Zone.Create(request.IsActive);

        await _unitOfWork.ZoneRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.ZoneNotInserted);
    }
}