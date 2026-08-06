using Application.Abstractions;

namespace Application.CQRS.InventoryStockCountDetailBatch.Commands;

public class UpdateInventoryStockCountDetailBatchCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? InventoryStockCountDetailFk { get; set; }
        public int? BatchFk { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? CountQuantity { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryStockCountDetailBatchCommandHandler : ICommandHandler<UpdateInventoryStockCountDetailBatchCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryStockCountDetailBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryStockCountDetailBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryStockCountDetailBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryStockCountDetailBatchNotFound);

        entity.Update(request.InventoryStockCountDetailFk, request.BatchFk, request.Quantity, request.CountQuantity, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryStockCountDetailBatchNotUpdated);
    }
}