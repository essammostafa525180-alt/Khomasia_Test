using Application.Abstractions;

namespace Application.CQRS.InventoryTransfereDetailBatch.Commands;

public class DeleteInventoryTransfereDetailBatchCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteInventoryTransfereDetailBatchCommandHandler : ICommandHandler<DeleteInventoryTransfereDetailBatchCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInventoryTransfereDetailBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteInventoryTransfereDetailBatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryTransfereDetailBatchRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryTransfereDetailBatchNotFound);

        _unitOfWork.InventoryTransfereDetailBatchRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryTransfereDetailBatchNotDeleted);
    }
}