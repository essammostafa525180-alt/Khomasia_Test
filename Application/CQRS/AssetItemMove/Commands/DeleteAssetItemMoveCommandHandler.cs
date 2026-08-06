using Application.Abstractions;

namespace Application.CQRS.AssetItemMove.Commands;

public class DeleteAssetItemMoveCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetItemMoveCommandHandler : ICommandHandler<DeleteAssetItemMoveCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetItemMoveCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetItemMoveCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetItemMoveRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetItemMoveNotFound);

        _unitOfWork.AssetItemMoveRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetItemMoveNotDeleted);
    }
}