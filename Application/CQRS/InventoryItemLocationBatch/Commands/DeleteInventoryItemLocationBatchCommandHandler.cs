using Application.Abstractions;

namespace Application.CQRS.InventoryItemLocationBatch.Commands;

public class DeleteInventoryItemLocationBatchCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryItemLocationBatchCommandHandler : ICommandHandler<DeleteInventoryItemLocationBatchCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryItemLocationBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryItemLocationBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryItemLocationBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryItemLocationBatchNotFound);

        _unitOfWork.InventoryItemLocationBatchRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryItemLocationBatchNotDeleted);
    }
}