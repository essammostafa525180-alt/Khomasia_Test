using Application.Abstractions;

namespace Application.CQRS.InventoryItemLocationBatch.Commands;

public class UpdateInventoryItemLocationBatchCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? InventoryItemLocationFk { get; set; }
        public string? BatchNumber { get; set; }
        public int? ShelfFk { get; set; }
        public decimal? TotalQuantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public long? InventoryItemFk { get; set; }
        public DateTime? ProductionDate { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryItemLocationBatchCommandHandler : ICommandHandler<UpdateInventoryItemLocationBatchCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryItemLocationBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryItemLocationBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemLocationBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemLocationBatchNotFound);

        entity.Update(request.InventoryItemLocationFk, request.BatchNumber, request.ShelfFk, request.TotalQuantity, request.ExpiryDate, request.InventoryItemFk, request.ProductionDate, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemLocationBatchNotUpdated);
    }
}