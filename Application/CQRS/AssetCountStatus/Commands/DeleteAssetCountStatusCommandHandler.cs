using Application.Abstractions;

namespace Application.CQRS.AssetCountStatus.Commands;

public class DeleteAssetCountStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetCountStatusCommandHandler : ICommandHandler<DeleteAssetCountStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetCountStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetCountStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetCountStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetCountStatusNotFound);

        _unitOfWork.AssetCountStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetCountStatusNotDeleted);
    }
}