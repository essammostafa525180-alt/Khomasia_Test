using Application.Abstractions;

namespace Application.CQRS.InventoryStockCountDetailBatch.Commands;

public class DeleteInventoryStockCountDetailBatchCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryStockCountDetailBatchCommandHandler : ICommandHandler<DeleteInventoryStockCountDetailBatchCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryStockCountDetailBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryStockCountDetailBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryStockCountDetailBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryStockCountDetailBatchNotFound);

        _unitOfWork.InventoryStockCountDetailBatchRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryStockCountDetailBatchNotDeleted);
    }
}