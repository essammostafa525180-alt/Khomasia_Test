using Application.Abstractions;

namespace Application.CQRS.InventoryItemAsset.Commands;

public class DeleteInventoryItemAssetCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryItemAssetCommandHandler : ICommandHandler<DeleteInventoryItemAssetCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryItemAssetCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryItemAssetCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemAssetRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemAssetNotFound);

        _unitOfWork.InventoryItemAssetRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemAssetNotDeleted);
    }
}