using Application.Abstractions;

namespace Application.CQRS.InventoryItemAsset.Commands;

public class UpdateInventoryItemAssetCommand : ICommand<Result>
{
        public int Id { get; set; }
        public long? InventoryItemFk { get; set; }
        public int? AssetFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryItemAssetCommandHandler : ICommandHandler<UpdateInventoryItemAssetCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryItemAssetCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryItemAssetCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemAssetRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemAssetNotFound);

        entity.Update(request.InventoryItemFk, request.AssetFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemAssetNotUpdated);
    }
}