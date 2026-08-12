using Application.Abstractions;

namespace Application.CQRS.InventoryItemReturnBatch.Commands;

public class DeleteInventoryItemReturnBatchCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryItemReturnBatchCommandHandler : ICommandHandler<DeleteInventoryItemReturnBatchCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryItemReturnBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryItemReturnBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemReturnBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemReturnBatchNotFound);

        _unitOfWork.InventoryItemReturnBatchRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemReturnBatchNotDeleted);
    }
}