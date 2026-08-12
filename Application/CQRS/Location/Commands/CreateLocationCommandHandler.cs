using Application.Abstractions;

namespace Application.CQRS.Location.Commands;

public class CreateLocationCommand : ICommand<Result<int>>
{
        public bool IsActive { get; set; }
}
internal class CreateLocationCommandHandler : ICommandHandler<CreateLocationCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateLocationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.LocationAggregate.Location.Create(request.IsActive);

        await _unitOfWork.LocationRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.LocationNotInserted);
    }
}