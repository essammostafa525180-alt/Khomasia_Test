using Application.Abstractions;

namespace Application.CQRS.AssetComponent.Commands;

public class DeleteAssetComponentCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetComponentCommandHandler : ICommandHandler<DeleteAssetComponentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetComponentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetComponentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetComponentRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetComponentNotFound);

        _unitOfWork.AssetComponentRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetComponentNotDeleted);
    }
}