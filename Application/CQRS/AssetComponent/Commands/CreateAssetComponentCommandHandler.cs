using Application.Abstractions;

namespace Application.CQRS.AssetComponent.Commands;

public class CreateAssetComponentCommand : ICommand<Result<int>>
{
        public int? AssetFk { get; set; }
        public int? ComponentFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssetComponentCommandHandler : ICommandHandler<CreateAssetComponentCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetComponentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetComponentCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.AssetAggregate.AssetComponent.Create(request.AssetFk, request.ComponentFk, request.IsActive);

        await _unitOfWork.AssetComponentRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetComponentNotInserted);
    }
}