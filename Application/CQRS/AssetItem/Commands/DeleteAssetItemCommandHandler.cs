using Application.Abstractions;

namespace Application.CQRS.AssetItem.Commands;

public class DeleteAssetItemCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAssetItemCommandHandler : ICommandHandler<DeleteAssetItemCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetItemCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAssetItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssetItemRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssetItemNotFound);

        _unitOfWork.AssetItemRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssetItemNotDeleted);
    }
}