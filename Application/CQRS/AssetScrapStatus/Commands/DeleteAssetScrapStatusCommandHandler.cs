using Application.Abstractions;

namespace Application.CQRS.AssetScrapStatus.Commands;

public class DeleteAssetScrapStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetScrapStatusCommandHandler : ICommandHandler<DeleteAssetScrapStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetScrapStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetScrapStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetScrapStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetScrapStatusNotFound);

        _unitOfWork.AssetScrapStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetScrapStatusNotDeleted);
    }
}