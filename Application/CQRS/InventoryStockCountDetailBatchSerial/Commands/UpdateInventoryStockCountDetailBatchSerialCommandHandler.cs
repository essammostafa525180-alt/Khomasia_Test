using Application.Abstractions;

namespace Application.CQRS.InventoryStockCountDetailBatchSerial.Commands;

public class UpdateInventoryStockCountDetailBatchSerialCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? InventoryStockCountDetailBatchFk { get; set; }
        public int? InventoryItemLocationBatchSerialFk { get; set; }
        public bool IsNew { get; set; }
        public bool IsSerialExist { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryStockCountDetailBatchSerialCommandHandler : ICommandHandler<UpdateInventoryStockCountDetailBatchSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryStockCountDetailBatchSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryStockCountDetailBatchSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryStockCountDetailBatchSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryStockCountDetailBatchSerialNotFound);

        entity.Update(request.InventoryStockCountDetailBatchFk, request.InventoryItemLocationBatchSerialFk, request.IsNew, request.IsSerialExist, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryStockCountDetailBatchSerialNotUpdated);
    }
}