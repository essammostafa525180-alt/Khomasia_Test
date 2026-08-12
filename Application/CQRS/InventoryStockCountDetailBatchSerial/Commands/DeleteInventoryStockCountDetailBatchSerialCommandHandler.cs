using Application.Abstractions;

namespace Application.CQRS.InventoryStockCountDetailBatchSerial.Commands;

public class DeleteInventoryStockCountDetailBatchSerialCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryStockCountDetailBatchSerialCommandHandler : ICommandHandler<DeleteInventoryStockCountDetailBatchSerialCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryStockCountDetailBatchSerialCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryStockCountDetailBatchSerialCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryStockCountDetailBatchSerialRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryStockCountDetailBatchSerialNotFound);

        _unitOfWork.InventoryStockCountDetailBatchSerialRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryStockCountDetailBatchSerialNotDeleted);
    }
}