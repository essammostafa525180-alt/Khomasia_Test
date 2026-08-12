using Application.Abstractions;

namespace Application.CQRS.InventoryItemAsset.Commands;

public class CreateInventoryItemAssetCommand : ICommand<Result<int>>
{
        public long? InventoryItemFk { get; set; }
        public int? AssetFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateInventoryItemAssetCommandHandler : ICommandHandler<CreateInventoryItemAssetCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryItemAssetCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryItemAssetCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryItemAggregate.InventoryItemAsset.Create(request.InventoryItemFk, request.AssetFk, request.IsActive);

        await _unitOfWork.InventoryItemAssetRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryItemAssetNotInserted);
    }
}